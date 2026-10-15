using System;
using System.Collections.Generic;

public class Karyawan
{
    public string Nama;
    public double Gaji;

    public Karyawan(string nama, double gaji)
    {
        this.Nama = nama;
        this.Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja");
    }

    public void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}");
    }
}

public class Tetap : Karyawan
{
    public double Tunjangan;


    public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
    {
        this.Tunjangan = tunjangan;
        this.Nama = nama;
        this.Gaji = gaji;
    }

    public void HitungGajiTotal()
    {
        double gajiTotal = Gaji + Tunjangan;
        Console.WriteLine($"Gaji Total {Nama}: {gajiTotal}");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja sebagai karyawan tetap");
    }
}

public class Kontrak : Karyawan
{
    public int Durasi;

    public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
    {
        this.Durasi = durasi;
        this.Nama = nama;
        this.Gaji = gaji;
    }
    public void CekKontrak()
    {
        Console.WriteLine($"Durasi kontrak {Nama}: {Durasi} bulan");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja sebagai karyawan kontrak");
    }
}

public class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan)
    {
        this.Nama = nama;
        this.Gaji = gaji;
        this.Tunjangan = tunjangan;
    }

    public void Memimpin()
    {
        Console.WriteLine($"{Nama} sedang memimpin tim");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{Nama} sedang mengelola tim");
    }
}

public class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan)
    {
        this.Nama = nama;
        this.Gaji = gaji;
        this.Tunjangan = tunjangan;
    }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{Nama} sedang mengerjakan tugas");
    }
    public void kerja()
    {
        Console.WriteLine($"{Nama} sedang mengerjakan tugas");
    }
}

public class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi)
    {
        this.Nama = nama;
        this.Gaji = gaji;
        this.Durasi = durasi;
    }
    
    public void Belajar()
    {
        Console.WriteLine($"{Nama} sedang belajar");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} sedang magang selama {Durasi} bulan");
    }
}

public class Freelance : Kontrak
{
    public Freelance(string nama, double gaji, int durasi) : base(nama, gaji, durasi)
    {
        this.Nama = nama;
        this.Gaji = gaji;
        this.Durasi = durasi;
    }
    public void AmbilProyek()
    {
        Console.WriteLine($"{Nama} sedang mengambil proyek");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja sebagai freelancer selama {Durasi} bulan");
    }
}

public class Perusahaan
{
    public List<Karyawan> Karyawans = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        Karyawans.Add(karyawan);
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("Daftar Karyawan:");
        foreach (var karyawan in Karyawans)
        {
            karyawan.InfoKaryawan();
        }
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        Perusahaan perusahaan = new Perusahaan();

        Manager manager = new Manager("Andi", 8000000, 2000000);
        Staff staff = new Staff("Budi", 5000000, 1000000);
        Magang magang = new Magang("Citra", 2000000, 6);
        Freelance freelance = new Freelance("Doni", 4000000, 3);

        perusahaan.TambahKaryawan(manager);
        perusahaan.TambahKaryawan(staff);
        perusahaan.TambahKaryawan(magang);
        perusahaan.TambahKaryawan(freelance);

        perusahaan.DaftarKaryawan();

        Console.WriteLine("\nDemonstrasi Polymorphism:");
        foreach (Karyawan karyawan in perusahaan.Karyawans)
        {
            karyawan.Kerja();
        }

        Console.WriteLine("\nMethod Khusus:");
        manager.Memimpin();
        staff.KerjakanTugas();
        magang.Belajar();
        freelance.AmbilProyek();   
    }
}