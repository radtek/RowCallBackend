package example;
import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.xml.ws.Endpoint;
import java.util.Date;


@WebService()
public class HelloWorld {
  @WebMethod
  public String sayHelloWorldFrom()
  {
    Date date = new Date();
    String result = date.toString();
    return result;
  }

  public static void main(String[] argv)
  {
    Object implementor = new HelloWorld ();
    String address = "http://localhost:9000/HelloWorld";
    Endpoint.publish(address, implementor);
    System.out.println("Server is running");

  }
}

