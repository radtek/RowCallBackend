package example;
import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.xml.ws.Endpoint;
import java.util.Date;

@WebService()
public class GetDate
{
  @WebMethod
  public String getDate()
  {
      String result = new Date().toString();
      System.out.println(result);
      return result;
  }
  public static void main(String[] argv)
  {
    Object implementor = new GetDate();
    String address = "http://localhost:9000/Date";
    Endpoint.publish(address, implementor);
    System.out.println("Server is running");
  }
}
