using System;

namespace PostService
{
    class Program
    {
        static void Main(string[] args)
        {
            PostService postService = new PostService(1000); // создаем экземпляр класса PostService с лимитом веса 1000

            Parcel parcel1 = new Parcel("Книга", 500); // создаем экземпляр класса Parcel с описанием "Книга" и весом 500
            postService.SendParcel(parcel1); // отправляем посылку

            Parcel parcel2 = new Parcel("Посуда", 600); // создаем экземпляр класса Parcel с описанием "Посуда" и весом 600
            postService.SendParcel(parcel2); // отправляем посылку

            Parcel parcel3 = new Parcel("Одежда", 200); // создаем экземпляр класса Parcel с описанием "Одежда" и весом 200
            postService.SendParcel(parcel3); // отправляем посылку

            Console.ReadKey();
        }
    }

    class Parcel
    {
        public string Description { get; set; } // свойство описания посылки
        public int Weight { get; set; } // свойство веса посылки

        public Parcel(string description, int weight) // конструктор класса Parcel
        {
            Description = description;
            Weight = weight;
        }
    }

    class PostService
    {
        private int weightLimit; // лимит веса отправленных посылок
        private int totalWeight; // общий вес отправленных посылок

        public PostService(int weightLimit) // конструктор класса PostService
        {
            this.weightLimit = weightLimit;
            totalWeight = 0;
        }

        public void SendParcel(Parcel parcel) // метод отправки посылки
        {
            if (totalWeight + parcel.Weight > weightLimit) // если общий вес отправленных посылок превысил лимит
            {
                Console.WriteLine("Превышен лимит веса отправленных посылок!");
                return;
            }

            totalWeight += parcel.Weight; // увеличиваем общий вес отправленных посылок
            Console.WriteLine($"Отправлена посылка: {parcel.Description} ({parcel.Weight} гр)");
        }
    }
}