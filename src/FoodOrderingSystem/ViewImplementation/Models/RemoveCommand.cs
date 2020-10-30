namespace ViewImplementation.Models
{
    internal class RemoveCommand : Command
    {
        protected string phonenumber;
        protected char digit_to_remove;


        public RemoveCommand(string phonenumber)
        {

            base.phoneNum = phonenumber;
            digit_to_remove = phonenumber[phonenumber.Length - 1];              
        }

        public override string execute()
        {
            if (phoneNum.Length == 11)
            {
                phoneNum = phoneNum.Remove(phoneNum.Length - 1);
                return phoneNum.Remove(phoneNum.Length - 1);
            }
            if (phoneNum.Length == 7)
            {
                phoneNum = phoneNum.Remove(phoneNum.Length - 1);
                phoneNum = phoneNum.Remove(phoneNum.Length - 1);
                return phoneNum.Remove(phoneNum.Length - 1);
            }
            if (phoneNum.Length == 2)
            {
                phoneNum = phoneNum.Remove(phoneNum.Length - 1);
                return phoneNum.Remove(phoneNum.Length - 1);
            }
            return phoneNum.Remove(phoneNum.Length - 1);
        }
    }
}