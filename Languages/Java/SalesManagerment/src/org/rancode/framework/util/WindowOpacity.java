package org.rancode.framework.util;


/**
 * 
 * 说明:窗口渐入渐出工具类
 * 
 * @author LS
 * 
 * */
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
/**
 * 窗口淡入淡出
 * */
import javax.swing.JFrame;
import javax.swing.Timer;

import com.sun.awt.AWTUtilities;

public class WindowOpacity {
	
	public WindowOpacity(final JFrame jframe) {
		// 窗口设置淡入淡出代码段
		AWTUtilities.setWindowOpacity(jframe, 0f);
		ActionListener lisener = new ActionListener() {

			float alpha = 0;

			@Override
			public void actionPerformed(ActionEvent e) {
				if (alpha < 0.9) {
					AWTUtilities.setWindowOpacity(jframe, alpha += 0.1);
				} else {
					AWTUtilities.setWindowOpacity(jframe, 1);
					Timer source = (Timer) e.getSource();
					source.stop();
				}
			}
		};
		// 设置线程控制
		new Timer(50, lisener).start();
	}
}
