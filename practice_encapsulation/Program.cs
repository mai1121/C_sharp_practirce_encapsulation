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

            var m = new Member();
            //インデクサーにアクセス
            var memberList = new string[] {"ゆきこ","愛子","皐月","春子","昌美" };
            for(var i = 0; i < 5; i++)
            {
                m[i] = memberList[i];
                Console.WriteLine(m[i]);
            }

            var p = new Price(4);
            p[0] = 390;
            p[1] = 230;
            p[2] = 500;
            p[3] = 450;

            Console.WriteLine($"合計で{p.Total()}円");
        }
    }

    #region BMIクラス定義（プロパティ練習用）
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
    #endregion

    class Member
    {
        //privateなフィールド定義、初期化する
        private string[] member=new string[5];

        //インデクサー
        public string this[int i]
        {
            set { this.member[i] = value; }
            get { return this.member[i]; }

        }
    }

    class Price
    {
        private int size; //配列サイズをフィールド定義
        private int[] list; //空の配列をフィールド定義

        //コンストラクター（フィールド初期化）
        public Price(int size)
        {
            this.size = size;
            this.list = new int[size];
        }
        //インデクサー
        public int this[int index]
        {
            set { this.list[index] = value; }
            get { return this.list[index]; }
        }
        //インデクサーでセットしたフィールド値使って合計金額計算するメソッド
        public int Total()
        {
            int total = 0;
            foreach(var i in list)
            {
                total += i;
            }
            return total;
        }
    }

}
