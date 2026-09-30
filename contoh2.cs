//game
//karakter : nama, kesehatan, 
//setter yaitu utk mengisi atrbut
//this utk menunjuk var di dalem class

using System;
using System.Collections.Generic;
namespace KerangkaGame
{
    class Karakter
    {
        // public string kesehatan, senjata;
        public int total, power;

        //Encapsulation
        public string nama{ get; private set; }
        public int kesehatan{ get; private set; }
        public int senjata{ get; private set; }
        public int healing{ get; private set; } // Menambahkan property healing dengan encapsulation
        

        // Constructor disesuaikan menerima 4 parameter agar cocok dengan player1
        public Karakter(string nama, int kesehatan, int senjata, int healing = 0)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.healing = healing;
        }

        public void Serang(Karakter target) //Membuat medhod menyerang, contoh interaksi antar objek
        {
            Console.WriteLine("===== Mulai Serangan =====");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int JumlahSerangan) //Objek menerima serangan, contoh interaksi antar objek
        {
            kesehatan -= JumlahSerangan;
            Console.WriteLine($"{nama} menerima serangan sebesar {JumlahSerangan}. Kesehatan sekarang: {kesehatan}");
        }

        public void PakaiHealing() // Method baru untuk memicu aksi penyembuhan diri sendiri memakai nilai 'healing' objek tersebut
        {
            Console.WriteLine("===== Mulai Penyembuhan =====");
            this.ProsesHealing(this.healing);
        }

        public void ProsesHealing(int JumlahHealing) //Objek menerima serangan, contoh interaksi antar objek
        {
            kesehatan += JumlahHealing;
            Console.WriteLine($"{nama} menerima penyembuhan sebesar {JumlahHealing}. Kesehatan sekarang: {kesehatan}");
        }


        public void getData()
        {
            Console.WriteLine($"Karakter: {nama} | Kesehatan: {kesehatan}");
        }
    
     
    } // Penutup class Karakter

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Anby", 100, 10, 20); 
            Karakter Musuh = new Karakter("Etherial", 100, 30);

            //Interaksi antar objek
            player1.Serang(Musuh); //Objek player1 menyerang objek Musuh
            Musuh.Serang(player1); //Objek Musuh menyerang objek player1
            
            player1.PakaiHealing(); 

            Console.WriteLine("\n===== STATUS AKHIR =====");
            player1.getData(); //Menampilkan data player1

        }
    }
} // Penutup namespace KerangkaGame dipindahkan ke paling bawah
