package org.rancode.framework.util;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Properties;

public class test {

	/**
	 * @param args
	 * @throws IOException 
	 */
	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
        System.out.println(JdbcUtil.class.getResource(""));
        System.out.println(JdbcUtil.class.getResource("/"));
        System.out.println(JdbcUtil.class.getResourceAsStream("/"));
        
       
          Properties prop = new Properties();  
          FileInputStream fis =   
            new FileInputStream("sample.properties");  
          prop.load(fis);  
          prop.list(System.out);  
          System.out.println("\nThe foo property: " +  
              prop.getProperty("foo"));  


	}

}
