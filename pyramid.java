import java.io.*;
import java.util.*; 
class pyramid
{
   public static void main(String args[])
   {
    int i=0,j=0,k=1,f=0;
    Scanner reader = new Scanner(System.in);
    System.out.println("Enter a number: ");
    int n = reader.nextInt();
        for(i=0; i<=n; i++)
        {
           k+=i;  
          for(j=0; j<=(n+i); j++)
            {
               if(j<=(n-i-1))
                    System.out.print(" ");
                else
                {
                    f=k%10;  
                    System.out.print(""+f);
                    if(j<=(n-1))
                        k++;
                    else
                        k--;
                }
            }
            System.out.println(" ");
            k++;
        }
    }
}
