using System.Security.Cryptography;
using System.Text;

namespace TaskManagementApp.Helpers
{
    public class ConexionSegura
    {
        private static readonly string key = "PruebaEncriptar2018"; 

        public static string Encriptar(string textoPlano)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
                aes.IV = new byte[16];

                var encriptador = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encriptador, CryptoStreamMode.Write))
                    {
                        byte[] textoBytes = Encoding.Unicode.GetBytes(textoPlano);
                        cs.Write(textoBytes, 0, textoBytes.Length);
                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Desencriptar(string textoCifrado)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
                aes.IV = new byte[16];

                var desencriptador = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(textoCifrado)))
                {
                    using (var cs = new CryptoStream(ms, desencriptador, CryptoStreamMode.Read))
                    {
                        using (var sr = new System.IO.StreamReader(cs, Encoding.Unicode))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string ObtenerCadenaConexionSegura(IConfiguration configuration)
        {
            string cadenaEncriptada = configuration.GetConnectionString("DefaultConnection");
            return Desencriptar(cadenaEncriptada);
        }
    }
}
