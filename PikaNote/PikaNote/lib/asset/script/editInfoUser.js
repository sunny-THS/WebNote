const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});
async function changeAVT (avt) {
    const file = $(avt)[0].files[0];
    const base64 = await toBase64( file );
    $('#ContentWeb_imgUserProfile').attr('src', base64);
}
async function changeBg (avt) {
    const file = $(avt)[0].files[0];
    const base64 = await toBase64( file );
    $('#ContentWeb_imgBG').attr('src', base64);
}

//function toBase64(arr) {
//    //arr = new Uint8Array(arr) if it's an ArrayBuffer
//    return btoa(
//       arr.reduce((data, byte) => data + String.fromCharCode(byte), '')
//    );
//}