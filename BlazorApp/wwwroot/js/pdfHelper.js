// Función para descargar PDF en el navegador
window.downloadPdf = function (filename, base64Data) {
    // Convertir base64 a blob
    const byteCharacters = atob(base64Data);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    
    // Crear URL del blob
    const url = window.URL.createObjectURL(blob);
    
    // Abrir en nueva pestaña para previsualización
    window.open(url, '_blank');
    
    // Opcional: También descargar el archivo
    const link = document.createElement('a');
    link.href = url;
    link.download = filename;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    
    // Liberar el objeto URL después de un tiempo
    setTimeout(() => {
        window.URL.revokeObjectURL(url);
    }, 100);
};
