# ?? Resumen Rápido - Cómo Ejecutar las Pruebas JWT

## ?? Inicio Rápido (5 minutos)

### Paso 1: Preparar el Entorno
```bash
# Terminal 1: Iniciar WebAPI
cd WebAPI
dotnet run

# Terminal 2: Iniciar BlazorApp
cd BlazorApp
dotnet run
```

### Paso 2: Abrir Herramientas
1. Abre el navegador en `https://localhost:7080` (o el puerto de BlazorApp)
2. Presiona **F12** para abrir DevTools
3. Ve a la pestaña **Console**
4. En Visual Studio: `View ? Output ? Show output from: Debug`

---

## ?? Prueba 1: Token al Hacer Login (2 minutos)

### Hacer:
1. Ve a `/login`
2. Inicia sesión con:
   - Usuario: `[un profesor o alumno válido]`
   - Contraseña: `[su contraseña]`

### Esperar ver (en consola del navegador):
```
?? Token JWT recibido: eyJhbGc...
?? Usuario: tu_usuario
?? Tipo: Profesor
? Expira: 2025-01-27T...
?? Claims en el token:
  - nameidentifier: 1
  - name: tu_usuario
  - emailaddress: tu@email.com
  - role: Profesor
  - jti: guid...
```

### ? = Token generado correctamente
### ? = Revisar AuthService o appsettings.json

---

## ?? Prueba 2: Token en Peticiones (3 minutos)

### Hacer:
1. Ve a `/test-jwt`
2. Haz clic en "?? Llamar al Endpoint /especialidades"

### Esperar ver (consola del NAVEGADOR):
```
?? [APIEspecialidad.GetAllAsync] Enviando header: Bearer eyJhbG...
? Respuesta recibida: 5 especialidades
```

### Esperar ver (consola de VISUAL STUDIO):
```
=== ?? PRUEBA DE AUTENTICACIÓN ===
Authorization Header: Bearer eyJhbG...
? Usuario autenticado: tu_usuario
?? Claims del usuario:
  - nameidentifier: 1
  - name: tu_usuario
  - role: Profesor
```

### ? = JWT funcionando completamente
### ? = Revisar APIClientBase.AddAuthorizationHeaderAsync

---

## ?? Resultado Esperado

Si ves todos los mensajes ?:
- Tu implementación JWT está funcionando
- El token se genera correctamente
- El token se envía en las peticiones
- El backend valida el token
- Los claims se extraen correctamente

**¡Puedes empezar a proteger tus endpoints con JWT!**

---

## ? Atajos

- Ver página de pruebas: `https://localhost:7080/test-jwt`
- Ver consola navegador: `F12 ? Console`
- Ver consola VS: `Ctrl+Alt+O ? Debug`
- Decodificar token: `jwt.io`

---

## ?? Si algo falla

1. **No veo logs**: Asegúrate de que la consola correcta esté visible
2. **Token vacío**: Verifica que hayas iniciado sesión
3. **Usuario no autenticado**: Verifica JwtSettings en appsettings.json
4. **Error de conexión**: Asegúrate de que ambos proyectos estén corriendo

**Para más detalles**: Ver `GUIA_PRUEBAS_JWT.md`
