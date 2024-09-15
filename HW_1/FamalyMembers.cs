namespace hw1
{

    public enum Gender { Mуж, Жен }

    public class FamalyMembers
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public FamalyMembers Mother { get; set; }
        public FamalyMembers Father { get; set; }

        public FamalyMembers[] GetGrandParents()
        {
            return new FamalyMembers[] { Mother?.Mother, Mother?.Father, Father?.Mother, Father?.Father };
        }

        public FamalyMembers[] GetParents()
        {
            return new FamalyMembers[] { Mother, Father };
        }

        public string MemberInfo()
        {
            return $"=> {LastName} {Name} {Surname}\t (Пол {Gender}|Возраст {Age}) ";
        }
    }
}