using System;

namespace practice_encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var b1 = new BMI();
            //フィールドには直接アクセスできない保護レベルになっている
            //b1.weight = 80;　これはだめ
            b1.Weight = 89.5;
            b1.Height = 1.7;
            Console.WriteLine($"BMIは{ b1.GetBmi()}です");
            b1.FirstName = "村上";
            b1.LastName = "春樹";
            Console.WriteLine(b1.Name());
        }
    }

    class BMI
    {
        //フィールドはprivate権限で定義
        private double weight;
        private double height;

        //プロパティ定義。引数はない
        public double Weight
        {
            set
            {
                //入力値のチェック
                if (value <= 0)
                {
                    throw new ArgumentException("0より大きい数字で指定してください");
                }
                this.weight = value;
            }
            get { return this.weight; }
        }

        public double Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("0より大きい数字で指定してください");
                }
                this.height = value;
            }
            get { return this.height; }
        }
        //フィールド値操作するためのメソッド
        public double GetBmi()
        {
            return weight/(height * height);
        }

        //自動プロパティ定義
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //自動プロパティで作られたフィールドを操作するためのメソッド
        public string Name()
        {
            return $"名前は{this.FirstName}{this.LastName}です";
        }


    }
}
