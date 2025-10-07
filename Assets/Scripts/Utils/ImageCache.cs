using System;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class ImageCache
    {
        public static readonly string CACHE_PATH = Path.Combine(Application.persistentDataPath, "ImageCache");
        public static bool TryToLoadTexture(string url, TimeSpan ttl, out Texture2D texture)
        {
            texture = null;
            try
            {
                var path = PathFor(url);
                if (File.Exists(path) == false)
                {
                    return false;
                }
                var age  = DateTime.UtcNow - File.GetLastWriteTimeUtc(path);
                if (age > ttl)
                {
                    return false;
                }
                var bytes = File.ReadAllBytes(path);
                if (bytes == null || bytes.Length == 0)
                {
                    return false;
                }
                var tex2D = new Texture2D(2, 2, TextureFormat.RGBA32, false, false);
                if (ImageConversion.LoadImage(tex2D, bytes, false) == false)
                {
                    return false;
                }
                texture = tex2D;
                Debug.Log("Загрузка прошла успешно");
                Debug.Log(CACHE_PATH);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static void SaveTexture(Texture2D texture, string url)
        {
            try
            {
                if (texture == null)
                {
                    return;
                }
                var png = ImageConversion.EncodeToPNG(texture);
                if (png == null || png.Length == 0)
                {
                    return;
                }

                if (Directory.Exists(CACHE_PATH) == false)
                {
                    Directory.CreateDirectory(CACHE_PATH);
                }
                File.WriteAllBytes(PathFor(url), png);
                Debug.Log("Сохранение прошло успешно");
            }
            catch
            {
                Debug.Log("Не удалось сохранить текстуру");
            }
        }

        public static string PathFor(string url)
        {
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(url));
            var name  = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant() + ".png";
            return Path.Combine(CACHE_PATH, name);
        }
    }
}