using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Singly_Linked_List
{
    class Node
    {
        public int noMhs;
        public string nama;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNode()/*Method untuk mennambahkan sebuah node kedalam list*/
        {
            int nim;
            string nm;
            Console.Write("\nMasukkan nomer mahasiswa : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama mahasiswa : ");
            nm = Console.ReadLine();
            Node nodeBaru = new Node();
            nodeBaru.noMhs = nim;
            nodeBaru.nama = nm;

            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nNomer mahasiswa sama tidak diijinkan\n");
                    return;
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }

            /*Menemukan lokasi node baru di dalam list*/

            Node previous, current;

            previous = START;
            current = START;

            while ((current != null) && (nim >= current.noMhs))
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nNomer mahassiswa sama tidak diijinkan\n");
                    return ;
                }
                previous = current;
                current = current.next;
            }
            /*Node baru akan ditempatkan diantara previous dan current*/

            nodeBaru.next = current;
            previous.next = nodeBaru;
        }

        /*Method untuk menhapus node tertentu didalam list*/
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            /*Check apakah Node yang dimaksud ada dalam list atau tidak*/
            if ( Search (nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        /*Method untuk mengecheck apakah node yang dimaksud ada dalam list*/
        public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (nim != current.noMhs))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return(true);
        }
        /*Method untuk Trnverse/mengunjunngi dan membaca isi list*/
        public void Traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong. \n");
            else
            {
                Console.WriteLine("\nData dalam list adalah : \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + " " + currentNode.nama + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        class Program
        {
            static void Main(string[] args)
            {
                List ojb = new List();
                while(true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Menambah data kedalam list");
                        Console.WriteLine("2. Menghapus data dari dalam list");
                        Console.WriteLine("3. Melihat semua data diidalam list");
                        Console.WriteLine("4. Mencari sebuah data didalam list");
                        Console.WriteLine("5. Exit");
                        Console.Write("\nMasukkan pilihan anda (1-5) : ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    ojb.addNode();
                                }
                                break;
                            case '2':
                                {
                                    if (ojb.listEmpty())
                                    {
                                        Console.WriteLine("\nList kosong");
                                        break;
                                    }
                                    Console.Write("\nMasukkan nomor mahasiswa yang akan dihapus : ");
                                    int nim = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (ojb.delNode(nim) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                        Console.WriteLine("Data dengan nomor mahasiswa " + nim + " dihapus ");
                                }
                                break;
                            case '3':
                                {
                                    ojb.Traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (ojb.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList kosong !");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nMasukkan nomor mahasiswa yang akan dicari : ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (ojb.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                    {
                                        Console.WriteLine("\nData ketemu");
                                        Console.WriteLine("\nNomor mahasiswa : " + current.noMhs);
                                        Console.WriteLine("\nNama : " + current.nama);

                                    }
                                }
                                break;
                            case '5':
                                return;
                                default:
                                {
                                    Console.WriteLine("\nPilihan tidak valid");
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nCheck nilai yang anda masukkan.");
                    }
                }
            }
        }
    }
}
