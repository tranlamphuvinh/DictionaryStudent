using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien_HashTable
{
    public class SinhVien
    {
        public string name;
        public int age;
        public string gender;
        public float score;

        public string Name
        {
            get => name; set => name = value;
        }
        public int Age
        {
            get => age; set => age = value;
        }
        public string Gender
        {
            get => gender; set => gender = value;
        }
        public float Score
        {
            get => score; set => score = value;
        }

    }
}
