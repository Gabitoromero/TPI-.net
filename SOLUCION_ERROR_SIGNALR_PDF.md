# ?? Solución: Error de Circuito SignalR al Generar Reporte PDF

## ?? Error Original

```
[2025-10-28T00:04:35.0932] Error: There was an unhandled exception on the current circuit, so this circuit will be terminated. For more details turn on detailed exceptions by setting 'CircuitOptions.DetailedErrors: true' in 'appsettings.Development.json' or 'AddServerSideBlazor().AddCircuitOptions(options => options.DetailedErrors = true);'
```

---

## ?? Diagnóstico del Problema

### **Causa Raíz**

En **Blazor Server**, todo el código C# se ejecuta en el servidor y se comunica con el navegador mediante **SignalR**. Cuando generas un PDF:

1. El PDF se genera en el servidor (puede ser grande: 100KB-5MB)
2. Se convierte a Base64 (esto aumenta el tamaño ~33%)
3. Se envía al navegador a través de SignalR
4. **SignalR tiene límites de tamaño de mensaje** (por defecto 32KB)
5. Si el PDF es grande, **se excede el límite** ? **circuito se cierra** ? **error**

### **Factores Agravantes**

- Generación síncrona de PDF bloquea el circuito SignalR
- Sin timeout adecuado, el navegador piensa que perdió la conexión
- Sin manejo de errores específicos para SignalR

---

## ? Soluciones Implementadas

### **1. Generación Asíncrona del PDF (`AlumnoInscripciones.razor`)**

**Problema**: Generar el PDF bloqueaba el thread de SignalR

**Solución**: Usar `Task.Run()` para generar el PDF en un thread separado

```csharp
byte[] pdfBytes = await Task.Run(() =>
{
    var document = new PlanAlumnoReportDocument(datosReporte);
    return document.GeneratePdf();
});
```

**Beneficios**:
- ? No bloquea el circuito SignalR
- ? El navegador mantiene la conexión activa
- ? Mejor experiencia de usuario

---

### **2. Configuración de SignalR (`Program.cs`)**

**Problema**: Límites por defecto de SignalR son muy pequeños para PDFs

**Solución**: Aumentar límites y timeouts

```csharp
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        // Aumentar tamaño máximo de mensaje a 10MB
        options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10 MB
        
        // Aumentar timeouts
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
        options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    });
```

**Beneficios**:
- ? Permite PDFs grandes (hasta 10MB)
- ? Da más tiempo para generar el PDF
- ? Evita desconexiones prematuras

---

### **3. Mejor Manejo de Errores**

**Problema**: Errores genéricos sin información útil

**Solución**: Detectar errores específicos de SignalR

```csharp
catch (InvalidOperationException ex)
{
    errorReporte = "Error de conexión. Por favor, recargue la página e intente nuevamente.";
    Console.WriteLine($"? InvalidOperationException (SignalR): {ex.Message}");
}
catch (Exception ex)
{
    if (ex.Message.Contains("circuit") || ex.Message.Contains("SignalR"))
    {
        errorReporte = "La conexión con el servidor se perdió. Por favor, recargue la página (F5) e intente nuevamente.";
    }
}
```

**Beneficios**:
- ? Mensajes de error claros para el usuario
- ? Logs detallados para debugging
- ? Instrucciones de recuperación

---

### **4. Logs Detallados para Debugging**

Agregados logs en cada paso:

```csharp
Console.WriteLine($"?? Obteniendo datos del reporte para alumno ID: {alumnoId}");
Console.WriteLine($"? Datos obtenidos: {datosReporte.NombreCompleto}");
Console.WriteLine($"?? Generando PDF: {nombreArchivo}");
Console.WriteLine($"? PDF generado: {pdfBytes.Length} bytes");
Console.WriteLine($"?? Enviando PDF al navegador...");
Console.WriteLine($"? PDF enviado correctamente");
```

Estos logs aparecen en:
- **Consola del Navegador** (F12 ? Console)
- **Output de Visual Studio** (View ? Output ? Debug)

---

## ?? Cómo Probar la Solución

### **Paso 1: Reiniciar la Aplicación**

**IMPORTANTE**: Los cambios en `Program.cs` **requieren reinicio completo**

1. **Detener el debug** (Stop/Shift+F5)
2. **Cerrar el navegador** completamente
3. **Volver a ejecutar** (F5 o Start)

### **Paso 2: Abrir las Consolas de Log**

**Consola del Navegador**:
- Presionar **F12**
- Ir a la pestaña **Console**
- Dejar abierta para ver logs en tiempo real

**Output de Visual Studio**:
- Ir a **View** ? **Output**
- En el dropdown "Show output from:", seleccionar **Debug**

### **Paso 3: Probar la Generación del Reporte**

1. Iniciar sesión como **Alumno**
2. Ir a **"Mis Inscripciones"** (`/alumno/inscripciones`)
3. Clic en **"Generar Reporte Plan de Estudios"**
4. Confirmar en el modal
5. **Observar los logs**:

**Logs Esperados (Éxito)**:
```
?? Obteniendo datos del reporte para alumno ID: 123
? Datos obtenidos: Juan Pérez
?? Generando PDF: Plan_Estudios_Juan_Perez_20251028.pdf
? PDF generado: 245678 bytes
?? Enviando PDF al navegador...
? PDF enviado correctamente
```

**Logs de Error (Si falla)**:
```
? Exception: <mensaje de error>
StackTrace: <stack trace completo>
```

### **Paso 4: Verificar el Resultado**

Si funciona correctamente:
- ? El PDF se abre en nueva pestaña
- ? El PDF se descarga automáticamente
- ? El modal se cierra
- ? No hay errores en las consolas

Si falla:
- ? Aparece mensaje de error en el modal
- ? Logs muestran el error exacto
- ? El modal no se cierra

---

## ?? Troubleshooting

### **Error 1: "La conexión con el servidor se perdió"**

**Causa**: El circuito SignalR se cerró durante la generación

**Soluciones**:

1. **Recargar la página** (F5) e intentar nuevamente
2. **Verificar que los cambios se aplicaron**:
   - Reiniciar la aplicación completamente
   - No usar Hot Reload para cambios en `Program.cs`

3. **Revisar logs** para ver dónde falló exactamente

---

### **Error 2: "PDF muy grande, excede límite"**

**Causa**: El PDF es mayor a 10MB (muy raro)

**Soluciones**:

1. **Aumentar el límite en `Program.cs`**:
```csharp
options.MaximumReceiveMessageSize = 20 * 1024 * 1024; // 20 MB
```

2. **Reducir tamaño del logo** en `PlanAlumnoReportDocument.cs`
3. **Comprimir imágenes** si hay

---

### **Error 3: "QuestPDF License Error"**

**Causa**: Licencia no configurada o mal configurada

**Solución**: Verificar en `Program.cs`:
```csharp
QuestPDF.Settings.License = LicenseType.Community;
```

Debe estar **antes** de cualquier otro código.

---

### **Error 4: "JavaScript error: downloadPdf is not defined"**

**Causa**: El archivo `pdfHelper.js` no se cargó

**Soluciones**:

1. **Verificar que existe**: `BlazorApp\wwwroot\js\pdfHelper.js`
2. **Verificar referencia en `App.razor`**:
```html
<script src="js/pdfHelper.js"></script>
```
3. **Limpiar caché del navegador**: Ctrl+Shift+Delete

---

## ?? Comparación: Antes vs Después

| Aspecto | Antes | Después |
|---------|-------|---------|
| **Generación PDF** | Síncrona (bloquea SignalR) | Asíncrona (`Task.Run`) |
| **Límite mensaje** | 32 KB (default) | 10 MB |
| **Timeout cliente** | 30 seg (default) | 60 seg |
| **Manejo errores** | Genérico | Específico para SignalR |
| **Logs** | Básicos | Detallados en cada paso |
| **Experiencia usuario** | Se cuelga/falla | Funciona correctamente |

---

## ?? Archivos Modificados

1. ? **`BlazorApp\Program.cs`**
   - Configuración SignalR con límites aumentados
   - Timeouts mayores

2. ? **`BlazorApp\Components\Pages\AlumnoInscripciones.razor`**
   - Generación asíncrona del PDF
   - Mejor manejo de errores
   - Logs detallados

---

## ?? Parámetros de Configuración Recomendados

### **Para Desarrollo**:
```csharp
options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10 MB
options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
options.HandshakeTimeout = TimeSpan.FromSeconds(30);
```

### **Para Producción**:
```csharp
options.MaximumReceiveMessageSize = 5 * 1024 * 1024; // 5 MB (más restrictivo)
options.ClientTimeoutInterval = TimeSpan.FromSeconds(45);
options.HandshakeTimeout = TimeSpan.FromSeconds(20);
```

**Nota**: En producción, considera límites más bajos para seguridad.

---

## ?? Mejoras Futuras (Opcionales)

### **Opción 1: Generar PDF en el Cliente**

Usar una librería JavaScript para generar PDFs directamente en el navegador:
- ? No consume recursos del servidor
- ? No hay límites de SignalR
- ? Requiere reescribir el código de generación

### **Opción 2: Descargar PDF sin JavaScript**

Usar un endpoint API que devuelva el PDF directamente:
```csharp
// En WebAPI
[HttpGet("reporte-plan/{alumnoId}")]
public async Task<FileResult> GetReportePlan(int alumnoId)
{
    var datos = await obtenerDatos(alumnoId);
    var document = new PlanAlumnoReportDocument(datos);
    byte[] pdfBytes = document.GeneratePdf();
    return File(pdfBytes, "application/pdf", "plan.pdf");
}
```

Luego en Blazor:
```csharp
Navigation.NavigateTo($"/api/reporte-plan/{alumnoId}", forceLoad: true);
```

- ? Más simple
- ? Sin problemas de SignalR
- ? Requiere autenticación en el endpoint

### **Opción 3: Streaming del PDF**

Enviar el PDF en chunks (partes pequeñas):
- ? No hay límites de tamaño
- ? Más complejo de implementar

---

## ? Checklist de Verificación

Antes de probar:
- [x] `Program.cs` modificado con configuración SignalR
- [x] `AlumnoInscripciones.razor` modificado con `Task.Run`
- [x] Compilación exitosa
- [ ] **Aplicación reiniciada completamente** (no Hot Reload)
- [ ] Navegador cerrado y reabierto
- [ ] Consolas de log abiertas (F12 + Output VS)

Durante la prueba:
- [ ] Login como alumno exitoso
- [ ] Navegación a "Mis Inscripciones"
- [ ] Clic en "Generar Reporte"
- [ ] Modal de confirmación aparece
- [ ] Clic en "Confirmar"
- [ ] Logs aparecen en consola
- [ ] PDF se genera sin errores
- [ ] PDF se abre en nueva pestaña
- [ ] PDF se descarga automáticamente
- [ ] Modal se cierra

---

## ?? Conclusión

La solución aborda tres problemas principales:

1. **Generación Bloqueante** ? Solucionado con `Task.Run()`
2. **Límites de SignalR** ? Aumentados a 10MB
3. **Manejo de Errores** ? Mejorado con detección específica

**¡Ahora el reporte debería generarse correctamente!** ??

Si aún tienes problemas después de seguir estos pasos, **revisa los logs detallados** en ambas consolas para identificar el error exacto.

---

## ?? Referencias

- [Blazor SignalR Configuration](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/signalr)
- [QuestPDF Documentation](https://www.questpdf.com/)
- [Handling Large Messages in SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration)
