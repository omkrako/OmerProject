namespace OmerProject.Services
{
    public class LoginCounterService
    {
        private int _loginCount = 0;

        public void Increment()
        {
            _loginCount++;
        }

        public int GetCount()
        {
            return _loginCount;
        }
    }
}
