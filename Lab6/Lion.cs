namespace Lab6C_ {
    class Lion : IMeowable
    {
        public string name { get; set; }

        public Lion()
        {
            this.name = "�����";
        }

        public void meow()
        {
            Console.WriteLine($"{name}: ���!");
        }

        public override string ToString()
        {
            return "���: " + name;
        }

        public void meow(int c)
        {
            string s = $"{name}: ";
            for (int i = 0; i < c; i++)
            {
                if (i == 0) s += "���";
                else s += "-���";
            }
            s += "!";
            Console.WriteLine(s);
        }
    }
}