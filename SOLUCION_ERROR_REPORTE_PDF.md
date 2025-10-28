# ?? Solución: Error al Generar Reporte de Plan de Estudios

## ?? Problema

**Síntoma**: No se puede generar el reporte de plan de estudios en la aplicación Blazor.

**Error Probable**: 
```
QuestPDF requires a license. Visit https://www.questpdf.com/license/ for details.
```

---

## ? Causa Raíz

**QuestPDF requiere configurar una licencia** antes de generar documentos PDF, incluso para la versión Community (gratuita).

En **WinForms**, la licencia estaba configurada en `WinFormsApp\Program.cs`:
```csharp
QuestPDF.Settings.License = LicenseType.Community;
```

Pero en **Blazor**, esta configuración **no estaba presente**.

---

## ?? Solución Implementada

### **Modificado: `BlazorApp\Program.cs`**

Se agregó la configuración de licencia QuestPDF al inicio del `Program.cs`:

```csharp
using BlazorApp.Components;
using BlazorApp.Services;
using QuestPDF.Infrastructure;  // ? Agregar using

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ? Configurar licencia de QuestPDF (Community - Gratuita)
            QuestPDF.Settings.License = LicenseType.Community;

            var builder = WebApplication.CreateBuilder(args);
            
            // ... resto del código ...
        }
    }
}
```

---

## ?? Archivos Modificados

1. ? **`BlazorApp\Program.cs`** - Agregada configuración de licencia QuestPDF
2. ? **`BlazorApp\Components\Pages\AlumnoInscripciones.razor`** - Agregados logs detallados para debugging

---

## ?? Cómo Funciona la Generación de PDFs en Blazor

```
1. Usuario hace clic en "Generar Reporte Plan de Estudios"
   ?
2. Se obtiene el ID del alumno desde el token JWT (JwtHelper)
   ?
3. Se llama a ReportePlanAlumnoService.ObtenerDatosReporteAsync()
   ?
4. Se obtienen:
   - Datos del alumno
   - Plan de estudios
   - Especialidad
   - Materias del plan
   - Inscripciones y condiciones
   ?
5. Se crea una instancia de PlanAlumnoReportDocument con los datos
   ?
6. Se llama a document.GeneratePdf() ? Genera byte[] del PDF
   ?
7. Se convierte el byte[] a Base64
   ?
8. Se llama a JavaScript: downloadPdf(nombreArchivo, base64Data)
   ?
9. JavaScript:
   - Convierte Base64 a Blob
   - Abre el PDF en nueva pestaña (previsualización)
   - Descarga el archivo
   ?
10. ? Usuario ve y descarga el PDF
```

---

## ?? Cómo Probar la Solución

### **Paso 1: Reiniciar la Aplicación**
Como estás en debug, necesitas:
1. **Detener** la aplicación (Stop debugging)
2. **Volver a ejecutar** (F5 o Start)

### **Paso 2: Probar la Generación del Reporte**
1. Iniciar sesión como **Alumno**
2. Ir a **"Mis Inscripciones"** (`/alumno/inscripciones`)
3. Hacer clic en **"Generar Reporte Plan de Estudios"**
4. Confirmar en el modal
5. **Verificar**:
   - El PDF se genera correctamente
   - Se abre en nueva pestaña
   - Se descarga automáticamente

### **Paso 3: Verificar la Consola del Navegador**
Si hay algún error, los logs detallados aparecerán en:
- **Consola del Navegador** (F12 ? Console)
- **Output de Visual Studio** (View ? Output ? Show output from: Debug)

---

## ?? Información Adicional

### **Licencia QuestPDF Community**

La licencia **Community** de QuestPDF es **gratuita** y permite:
- ? Uso en proyectos personales
- ? Uso en proyectos educativos
- ? Uso en proyectos open-source
- ? Uso comercial con facturación anual < $1M USD

**Restricciones**:
- ? Debe incluir watermark en producción (opcional en desarrollo)
- ? Facturación anual > $1M USD requiere licencia Professional

Para más información: https://www.questpdf.com/license/

### **¿Por qué es necesario configurar la licencia?**

QuestPDF verifica la licencia al generar el primer documento PDF. Si no está configurada, lanza una excepción:
```
QuestPDF.Exceptions.LicenseException: QuestPDF requires a license.
```

Configurar `QuestPDF.Settings.License` **antes** de usar cualquier funcionalidad de QuestPDF es **obligatorio**, incluso para la versión gratuita.

---

## ?? Diferencias entre WinForms y Blazor

| Aspecto | WinForms | Blazor |
|---------|----------|--------|
| **Configuración de licencia** | `Program.Main()` | `Program.Main()` |
| **Generación de PDF** | `GeneratePdfAndShow()` | `GeneratePdf()` |
| **Previsualización** | Visor externo automático | JavaScript + nueva pestaña |
| **Descarga** | Guardar archivo local | Descarga del navegador |
| **Logging** | `Console.WriteLine()` | `Console.WriteLine()` (navegador) |

---

## ? Checklist de Verificación

- [x] Licencia QuestPDF configurada en `Program.cs`
- [x] `using QuestPDF.Infrastructure` agregado
- [x] Logs detallados en método `GenerarReportePlan()`
- [x] JavaScript `pdfHelper.js` presente y referenciado
- [x] Compilación exitosa
- [ ] **Pendiente**: Reiniciar aplicación y probar
- [ ] **Pendiente**: Verificar que el PDF se genera correctamente
- [ ] **Pendiente**: Verificar que se abre en nueva pestaña
- [ ] **Pendiente**: Verificar que se descarga automáticamente

---

## ?? Próximos Pasos

1. **Reiniciar la aplicación** (detener debug y volver a iniciar)
2. **Probar como alumno** la generación del reporte
3. **Verificar** que funcione correctamente
4. Si hay algún error, revisar:
   - Consola del navegador (F12)
   - Output de Visual Studio
   - Los logs agregados mostrarán información detallada

---

## ?? Troubleshooting

### **Si sigue sin funcionar después del reinicio:**

#### **Error 1: "Cannot read property 'GeneratePdf' of undefined"**
**Solución**: Verificar que QuestPDF esté instalado en BlazorApp:
```bash
dotnet list BlazorApp/BlazorApp.csproj package
```

Si no está, instalar:
```bash
dotnet add BlazorApp/BlazorApp.csproj package QuestPDF
```

#### **Error 2: "downloadPdf is not defined"**
**Solución**: Verificar que `pdfHelper.js` esté referenciado en `App.razor`:
```html
<script src="js/pdfHelper.js"></script>
```

#### **Error 3: "No se pudo obtener el ID del usuario"**
**Causa**: Token JWT no está presente o es inválido
**Solución**: Cerrar sesión y volver a iniciar sesión

#### **Error 4: "Usuario no encontrado"**
**Causa**: El ID del usuario en el token no existe en la base de datos
**Solución**: Verificar que el usuario existe en la base de datos

---

## ?? Conclusión

La solución fue simple pero **crítica**:
- ? Agregar configuración de licencia QuestPDF en `Program.cs`
- ? Esto permite que QuestPDF genere PDFs sin errores
- ? Mantiene consistencia con WinForms

**¡El reporte debería funcionar ahora!** ??

---

## ?? Referencias

- [QuestPDF Documentation](https://www.questpdf.com/)
- [QuestPDF Licensing](https://www.questpdf.com/license/)
- [QuestPDF GitHub](https://github.com/QuestPDF/QuestPDF)
