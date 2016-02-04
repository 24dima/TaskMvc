using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    //Клас через який централізовано відбувається обмін данними в сервісі
    public class DataManager
    {
        private IUsersRepository usersRepository;
        private PrimaryMembershipProvider provider;
     
        public DataManager(IUsersRepository usersRepository, PrimaryMembershipProvider provider)
        {

           
            this.usersRepository = usersRepository;
            this.provider = provider;
          
        }

      
        public IUsersRepository Users { get { return usersRepository; } }
        
        public PrimaryMembershipProvider MembershipProvider { get { return provider; } }
    }
}
