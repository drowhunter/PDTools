﻿using System;

namespace PDTools.Crypto;

public class MCipherGT5
{
    public static byte[] Decrypt(Span<byte> buffer)
    {
        byte[] outBuf = new byte[buffer.Length - 8];
        if (DecryptImpl(buffer, outBuf, buffer.Length, 0x3039))
            return outBuf;
        return null;
    }

    private static bool DecryptImpl(Span<byte> buffer, Span<byte> outBuffer, int length, uint crcSeed)
    {
        int size = SharedCrypto.EncryptUnit_Decrypt(buffer, length, crcSeed, 0.327032387256622, 0.858476877212524, useMt: false, bigEndian: true);
        if (size > -1)
            buffer.Slice(8).CopyTo(outBuffer);
        return size > -1;
    }

    public static void Encrypt()
    {

    }
}

public class MCipherGT6
{
    public static byte[] Decrypt(Span<byte> buffer)
    {
        byte[] outBuf = new byte[buffer.Length];
        if (DecryptImpl(buffer, outBuf, buffer.Length, 0x3039))
            return outBuf;
        return null;
    }

    private static bool DecryptImpl(Span<byte> buffer, Span<byte> outBuffer, int length, uint crcSeed)
    {
        int size = SharedCrypto.EncryptUnit2_Decrypt(buffer, length, crcSeed, useMt: false, bigEndian: true);
        if (size > -1)
            buffer.Slice(8).CopyTo(outBuffer);
        return size > -1;
    }

    public static void Encrypt()
    {

    }
}

/// <summary>
/// Same as GT6
/// </summary>
public class MCipherGTS
{
    public static byte[] Decrypt(Span<byte> buffer)
    {
        byte[] outBuf = new byte[buffer.Length];
        if (DecryptImpl(buffer, outBuf, buffer.Length, 0x3039))
            return outBuf;
        return null;
    }

    private static bool DecryptImpl(Span<byte> buffer, Span<byte> outBuffer, int length, uint crcSeed)
    {
        int size = SharedCrypto.EncryptUnit2_Decrypt(buffer, length, crcSeed, useMt: false, bigEndian: true);
        if (size > -1)
            buffer.Slice(8).CopyTo(outBuffer);
        return size > -1;
    }

    public static void Encrypt()
    {

    }
}
