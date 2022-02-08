package OldFiles;

import javax.swing.JFrame;

import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class XIaohongNoteBook extends JFrame {

/**
	 * 
	 */
private static final long serialVersionUID = 1L;

private JPanel jp=new JPanel();

private JTextArea jta=new JTextArea();

private JScrollPane jsp=new JScrollPane(jta);//1

public XIaohongNoteBook(){

jp.setLayout(null);

jsp.setBounds(50,50,800,480);//jta.setBounds(20,20,150,100);

jp.add(jsp);//jp.add(jta);

jta.setLineWrap(true);

this.add(jp);

 

this.setTitle("Ð¡ºì¼ÇÊÂ");

this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

this.setResizable(false);

this.setBounds(100, 100, 860, 620);

this.setVisible(true);

}

public static void main(String[] args) {

new XIaohongNoteBook();

}

}

