using UnityEngine;
using com.berkecuhadar.unitydialoguegenerator.Runtime;
using UnityEngine.UI;

public class UGDRuntimeExampleTest : MonoBehaviour
{

    public Button buttons;
    string generatedText;
    UDGAgent agent = new UDGAgent();
    // Do not change ip and port 
    public string ip = "127.0.0.1";
    public int port = 65432;
    void Start()
    {
        agent.Init(ip,port,2);
        generatedText = agent.Generate("Hello World");
        Debug.Log("Input = Hello World");
        Debug.Log("Output = " + generatedText);
        

    }
    

}
