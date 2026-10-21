using System;
using System.Collections.Generic;

namespace KerangkaGame
{
    class Karakter
    {
        public int total, power;

        // Encapsulation
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }
        public int healing { get; private set; }
        public int posisiAwal { get; private set; }   
        public int posisiSaatIni { get; private set; }

        // Constructor
        public Karakter(string nama, int kesehatan, int senjata, int healing = 0, int posisiAwal = 0)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.healing = healing;
            this.posisiAwal = posisiAwal;
            this.posisiSaatIni = posisiAwal; 
        }

        public void Serang(Karakter target) // Interaksi antar objek: Menyerang
        {
            Console.WriteLine($"\n===== {nama} Mulai Serangan =====");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int JumlahSerangan) // Interaksi antar objek: Menerima serangan
        {
            kesehatan -= JumlahSerangan;
            Console.WriteLine($"{nama} menerima serangan sebesar {JumlahSerangan}. Kesehatan sekarang: {kesehatan}");
        }

        public void PakaiHealing() // Method untuk mendeteksi penggunaan Potion/Healing
        {
            Console.WriteLine($"\n===== {nama} Menggunakan Potion =====");
            this.ProsesHealing(this.healing);
        }

        public void ProsesHealing(int JumlahHealing)
        {
            kesehatan += JumlahHealing;
            Console.WriteLine($"{nama} mendapat penyembuhan sebesar {JumlahHealing}. Kesehatan sekarang: {kesehatan}");
        }

        public void PindahPosisiAngka() // Mode 1: perpindahan posisi pakai angka (loop, berhenti dengan Esc)
        {
            Console.WriteLine($"\n===== {nama} Pindah Posisi (Angka) =====");
            Console.WriteLine($"Posisi saat ini : {posisiSaatIni}");
            Console.WriteLine("Ketik angka lalu Enter untuk pindah  |  (Esc) berhenti");

            while (true) // perulangan tanpa batas sampai Esc ditekan
            {
                Console.Write("\nJumlah pindah: ");
                string buffer = "";

                while (true) // baca satu angka tombol-per-tombol sampai Enter / Esc
                {
                    ConsoleKeyInfo tombol = Console.ReadKey(true);

                    if (tombol.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("\npermainan Berhenti");
                        return; // keluar dari method -> permainan berhenti
                    }
                    else if (tombol.Key == ConsoleKey.Enter)
                    {
                        break; // selesai membaca angka, lanjut proses
                    }
                    else if (tombol.Key == ConsoleKey.Backspace && buffer.Length > 0)
                    {
                        buffer = buffer.Substring(0, buffer.Length - 1);
                        Console.Write("\b \b"); // hapus karakter terakhir dari layar
                    }
                    else if (tombol.KeyChar == '-' && buffer.Length == 0)
                    {
                        buffer += tombol.KeyChar;
                        Console.Write(tombol.KeyChar); // tanda minus untuk angka negatif
                    }
                    else if (char.IsDigit(tombol.KeyChar))
                    {
                        buffer += tombol.KeyChar;
                        Console.Write(tombol.KeyChar); // tampilkan angka yang diketik
                    }
                    // tombol lain diabaikan
                }

                Console.WriteLine(); // pindah baris setelah angka selesai diketik

                if (int.TryParse(buffer, out int jumlahPindah))
                {
                    posisiSaatIni += jumlahPindah; // update posisi saat ini sebanyak jumlah pindah
                    Console.WriteLine($"Pindah sebanyak {jumlahPindah}, posisi saat ini : {posisiSaatIni}");
                }
                else
                {
                    Console.WriteLine("Input salah! Tolong masukkan angka.");
                }
            }
        }

        public void PindahPosisiKeyboard() // Mode 2: perpindahan posisi pakai tombol keyboard
        {
            Console.WriteLine($"\n===== {nama} Pindah Posisi (Keyboard) =====");
            Console.WriteLine($"Posisi saat ini : {posisiSaatIni}");
            Console.WriteLine("Kontrol: (->) kanan = +2  |  (<-) kiri = -1  |  (Esc) berhenti");

            while (true)
            {
                ConsoleKeyInfo tombol = Console.ReadKey(true); // true = tombol tidak ditampilkan ke terminal

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    posisiSaatIni += 2; // arrow kanan -> posisi bertambah 2
                    Console.WriteLine($"-> Kanan  | posisi saat ini : {posisiSaatIni}");
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                    posisiSaatIni -= 1; // arrow kiri -> posisi berkurang 1
                    Console.WriteLine($"<- Kiri   | posisi saat ini : {posisiSaatIni}");
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("permainan Berhenti");
                    break; // keluar dari loop perpindahan
                }
                // tombol lain diabaikan
            }
        }

        public void getData()
        {
            Console.WriteLine($"Karakter: {nama} | Kesehatan: {kesehatan} | Posisi: {posisiSaatIni} (awal: {posisiAwal})");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Anby", 100, 40, 20, 0);   // posisi awal = 0
            Karakter Musuh = new Karakter("Etherial", 100, 30, 0);     // posisi awal = 0

            // Menu utama (muncul pertama)
            Console.WriteLine("\nMana yang kamu pilih?");
            Console.WriteLine();
            Console.WriteLine("1. Perpindahan Angka");
            Console.WriteLine("2. Tombol Keyboard");
            Console.WriteLine("3. Mainkan Game");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Pilihanmu: ");
                string pilihan = Console.ReadLine().Trim();

                if (pilihan == "1")
                {
                    player1.PindahPosisiAngka();
                    break;
                }
                else if (pilihan == "2")
                {
                    player1.PindahPosisiKeyboard();
                    break;
                }
                else if (pilihan == "3")
                {
                    MainkanGame(player1, Musuh);
                    break;
                }
                Console.WriteLine("Pilihan salah! Tolong masukkan '1', '2', atau '3'.");
            }

            // Status Akhir Game
            Console.WriteLine("\n===== STATUS AKHIR =====");
            player1.getData();
            Musuh.getData();
        }

        // Method "Mainkan Game": menjalankan method lain (Serang, PakaiHealing, dll)
        static void MainkanGame(Karakter player1, Karakter musuh)
        {
            // Simulasi Pertarungan Awal
            player1.Serang(musuh);
            musuh.Serang(player1);

            // Menampilkan status saat ini sebelum pilihan healing
            Console.WriteLine("\n===== STATUS SEKARANG =====");
            player1.getData();

            // Loop untuk validasi input Y/N
            while (true)
            {
                Console.Write($"\nApakah {player1.nama} ingin menggunakan Potion? (Y/N): ");
                string pilihan = Console.ReadLine().ToUpper().Trim();

                if (pilihan == "Y")
                {
                    player1.PakaiHealing();
                    break;
                }
                else if (pilihan == "N")
                {
                    Console.WriteLine($"\n{player1.nama} memilih untuk menyimpan Potion.");
                    break;
                }
                Console.WriteLine("Pilihan salah! Tolong masukkan hanya huruf 'Y' atau 'N'.");
            }
        }
    }
}
