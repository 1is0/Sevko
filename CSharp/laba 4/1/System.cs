using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class System
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GlobalMemoryStatusEx(Memory info);
        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern void GetSystemInfo(CPU info);
        public static string CPUInform()
        {
            CPU info = new CPU();
            GetSystemInfo(info);
            StringBuilder strPr = new StringBuilder();
            strPr.Append("Processor architecture is ");
            switch (info.ProcessorArchitecture)
            {
                case 0:
                    strPr.Append("x86\n");
                    break;
                case 5:
                    strPr.Append("ARM\n");
                    break;
                case 6:
                    strPr.Append("Itanium-based\n");
                    break;
                case 9:
                    strPr.Append("x64\n");
                    break;
                case 12:
                    strPr.Append("ARM64\n");
                    break;
                default:
                    strPr.Append("unknown\n");
                    break;
            }
            strPr.Append($"Number of processors is {info.NumberOfProcessors + 1}\n");
            return strPr.ToString();
        }
        public static string MemoryInform()
        {
            Memory info = new Memory();
            GlobalMemoryStatusEx(info);
            StringBuilder strMem = new StringBuilder();
            strMem.Append($"Memory architecture is {info.Length} bit\n");
            strMem.Append($"Used memory is {info.MemoryLoad}%\n");
            strMem.Append($"Total physical memory is {info.TotalPhys / Math.Pow(2, 30)} GB\n");
            strMem.Append($"Available physical memory is {info.AvailPhys / Math.Pow(2, 30)} GB\n");
            strMem.Append($"Committed memory limit is {info.TotalPageFile / Math.Pow(2, 30)} GB\n");
            strMem.Append($"Available committed memory is {info.AvailPageFile / Math.Pow(2, 30)} GB\n");
            strMem.Append($"Total virtual memory is {info.TotalVirtual / Math.Pow(2, 30)} GB\n");
            strMem.Append($"Availible virtual memory is {info.AvailVirtual / Math.Pow(2, 30)} GB\n");
            return strMem.ToString();
        }
    }
}
