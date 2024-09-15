
namespace hw1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FamalyMembers GrandFather1 = new()
            {
                Name = "Иван",
                Surname = "Сергеевич",
                LastName = "Иванов",
                Gender = Gender.Mуж,
                Age = 60
            };

            FamalyMembers GrandFather2 = new()
            {
                Name = "Аркадий",
                Surname = "Николаевич",
                LastName = "Петров",
                Gender = Gender.Mуж,
                Age = 64
            };

            FamalyMembers GrandMother1 = new()
            {
                Name = "Анна",
                Surname = "Викторовна",
                LastName = "Иванова",
                Gender = Gender.Жен,
                Age = 58
            };

            FamalyMembers GrandMother2 = new()
            {
                Name = "Лидия",
                Surname = "Александровна",
                LastName = "Петрова",
                Gender = Gender.Mуж,
                Age = 65
            };

            FamalyMembers Mother = new()
            {
                Name = "Лидия",
                Surname = "Ивановна",
                LastName = "Петрова",
                Gender = Gender.Жен,
                Age = 36,
                Mother = GrandMother1,
                Father = GrandFather1
            };

            FamalyMembers Father = new()
            {
                Name = "Петор",
                Surname = "Аркадиевич",
                LastName = "Петров",
                Gender = Gender.Mуж,
                Age = 73,
                Mother = GrandMother2,
                Father = GrandFather2
            };

            FamalyMembers Son = new()
            {
                Name = "Филипп",
                Surname = "Петрович",
                LastName = "Петров",
                Gender = Gender.Mуж,
                Age = 15,
                Mother = Mother,
                Father = Father
            };

            var GrandParents = Son.GetGrandParents();
            var Parents = Son.GetParents();

            Console.Write("Всем привет! давайте знакомиться, я\n" + Son.MemberInfo() + "\n");

            Console.WriteLine("\nМоими родителями являются\n");

            foreach (var item in Parents)
            {
                Console.WriteLine(item?.MemberInfo());
            }

            Console.WriteLine("\nУ меня есть Бабушки и Дедушки\n");
            foreach (var item in GrandParents)
            {
                Console.WriteLine(item?.MemberInfo());
            }
        }
    }
}