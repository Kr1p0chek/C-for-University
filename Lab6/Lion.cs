namespace Lab6C_ {
    class Lion : IMeowable
    {
        public string name { get; set; }

        public Lion()
        {
            this.name = "ׁטלבא";
        }

        public void meow()
        {
            Console.WriteLine($"{name}: לÿף!");
        }

        public override string ToString()
        {
            return "כוג: " + name;
        }

        public void meow(int c)
        {
            string s = $"{name}: ";
            for (int i = 0; i < c; i++)
            {
                if (i == 0) s += "לÿף";
                else s += "-לÿף";
            }
            s += "!";
            Console.WriteLine(s);
        }
    }
}