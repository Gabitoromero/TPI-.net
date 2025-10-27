# ?? Guía de Pruebas JWT - Verificación de Autenticación

## ?? Preparación

### 1. Iniciar los Proyectos
- Inicia **WebAPI** (API del backend)
- Inicia **BlazorApp** (aplicación web)

### 2. Abrir Herramientas de Desarrollo
- **Navegador**: Presiona `F12` para abrir las Herramientas de Desarrollador
- Ve a la pestaña **Console**
- **Visual Studio**: Ve a `View ? Output` y selecciona "Show output from: Debug"

---

## ?? Prueba 1: Verificar Token JWT Recibido al Hacer Login

### Pasos:
1. Navega a `/login` en tu navegador
2. Inicia sesión con credenciales válidas (usuario tipo Profesor o Alumno)
3. **Mira la consola del navegador (F12 ? Console)**

### ? Qué deberías ver en la consola:
```
?? Token JWT recibido: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
?? Usuario: [tu_usuario]
?? Tipo: Profesor/Alumno
? Expira: [fecha_hora]
?? Claims en el token:
  - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: [ID]
  - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name: [nombre]
  - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress: [email]
  - http://schemas.microsoft.com/ws/2008/06/identity/claims/role: [rol]
  - jti: [guid]
```

### ?? Verificación Adicional:
1. Copia el token que aparece en la consola
2. Ve a [jwt.io](https://jwt.io)
3. Pega el token en el campo "Encoded"
4. Verifica que veas:
   - **Header**: algoritmo HS256
   - **Payload**: tus claims (nameidentifier, name, email, role)
   - **Signature**: debe decir "Signature Verified" si pegas la clave secreta

---

## ?? Prueba 2: Verificar Token Enviado en las Peticiones

### Pasos:
1. Después de iniciar sesión, navega a `/test-jwt`
2. Verás tu información de usuario en la página
3. **Abre AMBAS consolas**:
   - Consola del **Navegador** (F12)
   - Consola de **Visual Studio** (Output ? Debug)
4. Haz clic en el botón "?? Llamar al Endpoint /especialidades"

### ? Qué deberías ver en la CONSOLA DEL NAVEGADOR:
```
=== ?? TEST JWT - INFORMACIÓN DEL TOKEN ===
Token: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
?? Claims en el token:
  http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier = [ID]
  http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name = [nombre]
  ...
? Token expira: [fecha]
==========================================

=== ?? INICIANDO PETICIÓN AL ENDPOINT ===
?? Enviando token: eyJhbGciOiJIUzI1Ni...
Endpoint: GET /especialidades
?? [APIEspecialidad.GetAllAsync] Enviando header: Bearer eyJhbGciOiJI...
? Respuesta recibida: [N] especialidades
==========================================
```

### ? Qué deberías ver en la CONSOLA DE VISUAL STUDIO (WebAPI):
```
=== ?? PRUEBA DE AUTENTICACIÓN ===
Authorization Header: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
? Usuario autenticado: [tu_usuario]
?? Claims del usuario:
  - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: [ID]
  - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name: [nombre]
  - http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress: [email]
  - http://schemas.microsoft.com/ws/2008/06/identity/claims/role: [rol]
  - jti: [guid]
=================================
```

### ?? En la página web deberías ver:
- ? Mensaje de éxito: "Se obtuvieron X especialidades correctamente"
- Lista de especialidades cargadas
- Información del usuario autenticado

---

## ? Problemas Comunes y Soluciones

### Problema 1: No se ve el token en la consola del navegador
**Causa**: No se instaló el paquete System.IdentityModel.Tokens.Jwt
**Solución**: Ejecutar `dotnet add BlazorApp package System.IdentityModel.Tokens.Jwt`

### Problema 2: "Usuario NO autenticado" en el backend
**Causas posibles**:
- El token no se está enviando en el header
- El token expiró
- La configuración JWT del backend no coincide

**Verificación**:
1. Verifica que veas `Authorization Header: Bearer ...` en el log
2. Si está vacío, el problema está en `APIClientBase.AddAuthorizationHeaderAsync`
3. Si tiene contenido pero dice "NO autenticado", verifica las claves JWT en `appsettings.json`

### Problema 3: Token expirado
**Verificación**: Mira el campo "? Expira" en los logs
**Solución**: Vuelve a iniciar sesión

### Problema 4: Error al llamar al endpoint
**Verificación**:
1. Asegúrate de que WebAPI esté corriendo
2. Verifica que la URL base en `APIClientBase` sea correcta (`https://localhost:7265/`)
3. Revisa los logs de error en la consola del navegador

---

## ? Checklist de Éxito

Marca cada punto cuando lo verifiques:

- [ ] El token JWT se genera al hacer login
- [ ] El token contiene todos los claims necesarios (nameidentifier, name, email, role)
- [ ] El token se puede decodificar en jwt.io
- [ ] El token se envía en el header `Authorization: Bearer ...`
- [ ] El backend recibe el token correctamente
- [ ] El backend puede autenticar al usuario con el token
- [ ] Los claims se extraen correctamente en el backend
- [ ] La página /test-jwt muestra la información del usuario
- [ ] El endpoint devuelve datos correctamente

---

## ?? Próximos Pasos

Una vez que ambas pruebas funcionen correctamente:

1. **Proteger más endpoints**: Agregar `.RequireAuthorization()` a otros endpoints
2. **Implementar roles**: Usar `.RequireAuthorization("Profesor")` o `.RequireAuthorization("Alumno")`
3. **Mejorar AuthStateService**: Implementar la obtención de UserId desde el token
4. **Persistir el token**: Guardar en localStorage o sessionStorage para que persista entre recargas
5. **Implementar refresh token**: Para renovar tokens expirados sin volver a hacer login

---

## ?? Notas Importantes

- Los logs de prueba solo deberían estar en desarrollo, **elimínalos en producción**
- El token se envía en **cada petición HTTP** automáticamente
- El token expira después de X minutos (configurable en `appsettings.json`)
- Si cierras sesión, el token se elimina de memoria
- En Blazor Server, el estado de autenticación se mantiene mientras la conexión SignalR esté activa

---

## ?? Archivos Modificados para las Pruebas

1. `BlazorApp\Components\Pages\Login.razor` - Logging del token al hacer login
2. `WebAPI\EspecialidadEndpoints.cs` - Logging del token recibido en el backend
3. `API.Clients\APIEspecialidad.cs` - Logging del token enviado en las peticiones
4. `BlazorApp\Components\Pages\TestJWT.razor` - Nueva página de pruebas

**Recuerda**: Estos logs son para desarrollo. Antes de subir a producción, elimina todos los `Console.WriteLine` relacionados con tokens.
