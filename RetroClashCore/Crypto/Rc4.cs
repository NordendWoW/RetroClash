﻿using System;
using System.Linq;
using System.Text;

namespace RetroClashCore.Crypto
{
    public class Rc4
    {
        public Rc4(byte[] key)
        {
            Key = Ksa(key);
        }

        public Rc4(string key)
        {
            Key = Ksa(Encoding.UTF8.GetBytes(key));
        }

        public byte[] Key { get; set; }

        public byte I { get; set; }

        public byte J { get; set; }

        public byte Prga()
        {
            I = (byte) ((I + 1) % 256);
            J = (byte) ((J + Key[I]) % 256);

            var temp = Key[I];
            Key[I] = Key[J];
            Key[J] = temp;

            return Key[(Key[I] + Key[J]) % 256];
        }

        public static byte[] Ksa(byte[] key)
        {
            var s = new byte[256];

            for (var i = 0; i != 256; i++)
                s[i] = (byte) i;

            byte j = 0;

            for (var i = 0; i != 256; i++)
            {
                j = (byte) ((j + s[i] + key[i % key.Length]) % 256);

                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
            return s;
        }
    }

    public class Rc4Core
    {
        public string InitialKey = Resources.Configuration.EncryptionKey;

        public Rc4Core()
        {
            InitializeCiphers(Encoding.UTF8.GetBytes(InitialKey + "nonce"));
        }

        public Rc4Core(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            InitializeCiphers(Encoding.UTF8.GetBytes(key));
        }

        public Rc4 Encryptor { get; set; }

        public Rc4 Decryptor { get; set; }

        public static byte[] GenerateNonce
        {
            get
            {
                var random = new Random();
                var buffer = new byte[random.Next(15, 25)];
                random.NextBytes(buffer);
                return buffer;
            }
        }

        public void Encrypt(ref byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            for (var k = 0; k < data.Length; k++)
                data[k] ^= Encryptor.Prga();
        }

        public void Decrypt(ref byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            for (var k = 0; k < data.Length; k++)
                data[k] ^= Decryptor.Prga();
        }

        public void UpdateCiphers(uint clientSeed, byte[] serverNonce)
        {
            if (serverNonce == null)
                throw new ArgumentNullException(nameof(serverNonce));

            InitializeCiphers(Encoding.UTF8.GetBytes(InitialKey + ScrambleNonce(clientSeed, serverNonce)));
        }

        public void InitializeCiphers(byte[] key)
        {
            Encryptor = new Rc4(key);
            Decryptor = new Rc4(key);

            for (var k = 0; k < key.Length; k++)
            {
                Encryptor.Prga();
                Decryptor.Prga();
            }
        }

        public static string ScrambleNonce(ulong clientSeed, byte[] serverNonce)
        {
            var scrambler = new Scrambler(clientSeed);
            var byte100 = 0;
            for (var i = 0; i < 100; i++)
                byte100 = scrambler.GetByte;
            return serverNonce.Aggregate(string.Empty,
                (current, t) => current + (char) (t ^ (scrambler.GetByte & byte100)));
        }
    }
}