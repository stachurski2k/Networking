using System;
using System.Text;
using System.Collections.Generic;
namespace CryptoLib
{
    public class Crypter
    {
        string key;
        byte[] byteKey;
        public void SetKey(string _key)
        {
            if (string.IsNullOrEmpty(_key))
            {
                key = "Secret";
            }
            if (_key.Length > 10)
            {
                key = _key.Substring(0, 9);
            }
            else if (_key.Length < 3)
            {
                key = _key;
                key += _key;
            }
            else
            {
                key = _key;
            }
            byteKey = Encoding.ASCII.GetBytes(key);
        }
        public string GetKey() { return key; }
        public Crypter(string _key)
        {
           SetKey(_key);
        }
        public Crypter()
        {
            SetKey("Key");
        }
        public byte[] Encrypt(string msg)
        {
            byte[] buff = Encoding.ASCII.GetBytes(msg);
            int keyindex=0;
            for (int i = 0; i < buff.Length-1; i++)
            {
                buff[i] = (byte)(((int)buff[i] + (int)byteKey[keyindex])%128);
                keyindex++;
                if (keyindex >= byteKey.Length)
                {
                    keyindex = 0;
                }
            }
            return buff;
        }
        public string Decrypt(string msg)
        {
            byte[] buff = Encoding.ASCII.GetBytes(msg);
            
            int keyindex = 0;
            for (int i = 0; i < buff.Length - 1; i++)
            {
                int res = ((int)buff[i] - (int)byteKey[keyindex]);
                if (res >= 128)
                {
                    res -= 128;
                }
                else if (res < 0)
                {
                    res = 128 + res;
                }
                buff[i] = (byte)res;
                keyindex++;
                if (keyindex >= byteKey.Length)
                {
                    keyindex = 0;
                }
            }
            msg = Encoding.ASCII.GetString(buff);
            return msg;
        }
    }
}
