using System;
using System.Collections.Generic;

namespace FundamentalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string lanjut;
            Activity a = new Activity();
            menu:
                int pilih;
                Console.WriteLine("Menu Program Mahasiswa");
                Console.WriteLine("=========================");
                Console.WriteLine("1. Hitung Nilai Mahasiswa");
                Console.WriteLine("2. Tambah Mahasiswa");
                Console.WriteLine("3. Lihat Data Mahasiswa");
                Console.WriteLine("4. Ubah Data Mahasiswa");
                Console.WriteLine("5. Hapus Data Mahasiswa");
                Console.WriteLine("=========================");
                Console.Write("Masukkan Pilihan (1-4) : ");
                pilih = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (pilih)
                {
                    case 1:
                        HitungGrade coba = new HitungGrade();
                        coba.LihatNilai();
                        break;
                    case 2:
                        Mahasiswa m = new Mahasiswa(a);
                         a.BuatMhs(m);
                        break;
                    case 3:
                        Console.WriteLine("Lihat Data Mahasiswa");
                        Console.WriteLine("=========================");
                        a.LihatMhs();
                        break;
                    case 4:
                        string mhsEdit;
                        if (a.mahasiswa.Count > 0)
                        {
                            Console.WriteLine("=====Ubah Mahasiswa========");
                            Console.Write("Masukkan NIM yang ingin diubah : ");
                            mhsEdit = Console.ReadLine();
                            a.UbahMhs(mhsEdit);
                        }
                        else
                        {
                            Console.WriteLine("data kosong");
                        }
                    break;
                    case 5:
                        if (a.mahasiswa.Count > 0)
                        {
                            Console.WriteLine("=====Hapus Mahasiswa========");
                            a.HapusMhs();
                        }
                        else
                        {
                            Console.WriteLine("data kosong");
                           
                        }
                    break;
                    default:
                        Console.WriteLine("PIlihan tidak terdaftar.");
                        Console.WriteLine("=========================");
                        break;
                }
            lanjutMenu:
                Console.WriteLine("Apakah mau dilanjut?");
                Console.WriteLine("Ketik 'y'/'Y' untuk balik ke menu awal atau 'n'/'N' untuk keluar");
                lanjut = (Console.ReadLine());
                Console.Clear();
            if (lanjut.ToLower() == "y")
            {
                goto menu;
            }
            else if (lanjut.ToLower() == "n")
            {
                Environment.Exit(0);
            }
            else {
                Console.WriteLine("Inputan salah");
                goto lanjutMenu;
            }
        }
    }
 
}
