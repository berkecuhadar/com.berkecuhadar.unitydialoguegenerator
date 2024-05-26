namespace com.berkecuhadar.unitydialoguegenerator.Runtime
{
    public class UDGAgent
    {
        private UDGCore core = new UDGCore();

        public void Init(string server, int port,int model)
        {
            core.Init(server, port,model);
        }


        public string Generate(string text)
        {
            return core.GenerateText(text);
        }
        public void StartServer()
        {
            core.StartServer();
        }
        public void CloseConn()
        {
            core.CloseConn();
        }
    }
}
