using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class RemoteMethod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public IntPtr lpSecurityDescriptor;
        public int bInheritHandle;
    }
    [Flags]
    enum ProcessAccessFlags : uint
    {
        All = 0x001F0FFF,
        Terminate = 0x00000001,
        CreateThread = 0x00000002,
        VMOperation = 0x00000008,
        VMRead = 0x00000010,
        VMWrite = 0x00000020,
        DupHandle = 0x00000040,
        SetInformation = 0x00000200,
        QueryInformation = 0x00000400,
        Synchronize = 0x00100000
    }
    [Flags]
    public enum AllocationType
    {
        Commit = 0x1000,
        Reserve = 0x2000,
        Decommit = 0x4000,
        Release = 0x8000,
        Reset = 0x80000,
        Physical = 0x400000,
        TopDown = 0x100000,
        WriteWatch = 0x200000,
        LargePages = 0x20000000
    }

    [Flags]
    public enum MemoryProtection
    {
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        NoAccess = 0x01,
        ReadOnly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08,
        GuardModifierflag = 0x100,
        NoCacheModifierflag = 0x200,
        WriteCombineModifierflag = 0x400
    }
    [DllImport("kernel32.dll")]
    static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    public static extern Int32 CloseHandle(IntPtr hProcess);

    [DllImport("kernel32.dll")]
    static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out uint lpThreadId);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);


    public int pId { get; set; }
    public IntPtr functionAddr { get; set; }

    public int registerEAX { get; set; }
    public bool writeEAX { get; set; }
    public int registerECX { get; set; }
    public bool writeECX { get; set; }
    public int registerEBX { get; set; }
    public bool writeEBX { get; set; }
    public int registerEDX { get; set; }
    public bool writeEDX { get; set; }
    public int registerESI { get; set; }
    public bool writeESI { get; set; }

    public List<int> paramList = new List<int>();

    private IntPtr pHandle = IntPtr.Zero;
    private IntPtr allocbase = IntPtr.Zero;

    public RemoteMethod(int processId)
    {
        pId = processId;
    }
    public static bool Is64Bit(IntPtr phandle)
    {
        if (!Environment.Is64BitOperatingSystem)
            return false;
        bool isWow64;
        if (!IsWow64Process(phandle, out isWow64))
            return false;
        return !isWow64;
    }
    public object[] allocateCall()
    {

        if (this.pHandle != IntPtr.Zero)
        {
            return new object[] { false, "Allocation already done, clear first" };
        }
        IntPtr pHandle = OpenProcess(ProcessAccessFlags.All, false, pId);
        if (pHandle == IntPtr.Zero)
        {
            return new object[] { false, "Cannot open the process" };
        }
        if (Is64Bit(pHandle))
        {
            CloseHandle(pHandle);
            return new object[] { false, "Cannot call function in a 64 bits process" };
        }

        IntPtr allocatedAddr = VirtualAllocEx(pHandle, (IntPtr)0x0, (IntPtr)4096, AllocationType.Commit, MemoryProtection.ExecuteReadWrite);
        if (allocatedAddr == IntPtr.Zero)
        {
            CloseHandle(pHandle);
            return new object[] { false, "Cannot allocate memory in the process" };
        }
        allocbase = allocatedAddr;
        this.pHandle = pHandle;
        return new object[] { true, "Allocation successfully" };
    }

    public object[] clearCall()
    {

        return new object[] { true, "" };
    }

    public object[] Call()
    {
        if (this.pHandle == IntPtr.Zero || allocbase == IntPtr.Zero)
        {
            return new object[] { false, "Allocation needed" };
        }

        List<byte> data = new List<byte>();

        foreach (int param in paramList)
        {
            data.Add(0xB8); // mov eax, number
            byte[] buffer = BitConverter.GetBytes(param);
            data.Add(buffer[0]); // addr
            data.Add(buffer[1]); // addr
            data.Add(buffer[2]); // addr
            data.Add(buffer[3]); // addr
            data.Add(0x50); // push eax
        }

        if (writeEAX)
        {
            data.Add(0xB8); // mov eax, number
            byte[] buffer = BitConverter.GetBytes(registerEAX);
            data.Add(buffer[0]); // addr
            data.Add(buffer[1]); // addr
            data.Add(buffer[2]); // addr
            data.Add(buffer[3]); // addr
        }
        if (writeECX)
        {
            data.Add(0xB9); // mov ecx, number
            byte[] buffer = BitConverter.GetBytes(registerECX);
            data.Add(buffer[0]); // addr
            data.Add(buffer[1]); // addr
            data.Add(buffer[2]); // addr
            data.Add(buffer[3]); // addr
        }
        if (writeEDX)
        {
            data.Add(0xBA); // mov edx, number
            byte[] buffer = BitConverter.GetBytes(registerEDX);
            data.Add(buffer[0]); // addr
            data.Add(buffer[1]); // addr
            data.Add(buffer[2]); // addr
            data.Add(buffer[3]); // addr
        }
        if (writeEBX)
        {
            data.Add(0xBB); // mov ebx, number
            byte[] buffer = BitConverter.GetBytes(registerEBX);
            data.Add(buffer[0]); // addr
            data.Add(buffer[1]); // addr
            data.Add(buffer[2]); // addr
            data.Add(buffer[3]); // addr
        }
        if (writeESI)
        {
            data.Add(0xBE); // mov esi, number
            byte[] buffer = BitConverter.GetBytes(registerESI);
            data.Add(buffer[0]); // addr
            data.Add(buffer[1]); // addr
            data.Add(buffer[2]); // addr
            data.Add(buffer[3]); // addr
        }

        data.Add(0xBF); // mov edi, number
        byte[] faddr = BitConverter.GetBytes(functionAddr.ToInt32());
        data.Add(faddr[0]); // addr
        data.Add(faddr[1]); // addr
        data.Add(faddr[2]); // addr
        data.Add(faddr[3]); // addr


        data.Add(0xFF); // call
        data.Add(0xD7); // edi
        data.Add(0xC3); // ret

        int writed;
        bool wresult = WriteProcessMemory(pHandle, allocbase, data.ToArray(), (uint)data.Count, out writed);

        if (!wresult || writed != data.Count)
        {
            return new object[] { false, "Error writing in the allocated area" };
        }

        uint id;
        IntPtr dwHandle = CreateRemoteThread(pHandle, IntPtr.Zero, 0x4096, allocbase, IntPtr.Zero, 0, out id);
        if (dwHandle == IntPtr.Zero)
        {
            return new object[] { false, "Unable to create thread!" };
        }
        return new object[] { true, "Call thread created successfully" }; ;
    }
}

