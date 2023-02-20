package OldFiles;

import java.awt.AWTException;
import java.awt.Dimension;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.Toolkit;
import java.awt.image.BufferedImage;
import java.net.*;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

public class ScreenVideo1D {
    @SuppressWarnings("static-access")
    public static void main(String[] args) {
        // 询问框问情况
        int choice = JOptionPane.showConfirmDialog(
                null, "来自本地监控程序的请求", "提示", JOptionPane.YES_NO_OPTION);
        System.out.println("程序启动!");
        // 判断
        if (choice == 1) {
            // 退出
            return;
        }
        String localip = "";
        try {
            // 获取IP
            InetAddress ip = null;
            ip = ip.getLocalHost();
            localip = ip.getHostAddress();
            System.out.println("IP获取成功");
        } catch (Exception e) {
            // 获取失败，提示错误并结束
            JOptionPane.showConfirmDialog(null, "我们遇到了不可解决的错误", "错误",
                    JOptionPane.OK_OPTION);
            System.out.println("IP获取失败");
            e.printStackTrace();
        }

        // 带输入框的提示框
        String result = JOptionPane.showInputDialog("请输入IP地址", localip);
        System.out.println("IP输入检测");
        if (result.equals(localip)) {
            JOptionPane.showConfirmDialog(null, "即将开始监控", "正常",
                    JOptionPane.OK_OPTION);
            System.out.println("IP正确,即将开始监控,正常");
        } else {
            JOptionPane.showConfirmDialog(null,
                    "连接失败"
                            + "异常被抛出",
                    "异常", JOptionPane.OK_OPTION);
            System.out.println("IP失败,连接失败，异常被抛出");
        }
        try {
            // 申请窗口
            JFrame c1 = new JFrame();
            c1.setVisible(true);
            System.out.println("申请窗口中");
            // 调整大小
            c1.setSize(1000, 850);
            System.out.println("调整大小中");
            int rtu = c1.getWidth();
            int rty = c1.getHeight();
            // 调整标题
            c1.setTitle("监控-屏幕实时监控(" + rtu + "," + rty + ")");
            System.out.println("调整标题中");
            // 调整起始位置
            c1.setLocationRelativeTo(null);
            System.out.println("调整起始位置中");
            // 置顶
            c1.setAlwaysOnTop(true);
            System.out.println("调整置顶项中");
            // 关闭时释放内存
            c1.setDefaultCloseOperation(c1.EXIT_ON_CLOSE);
            System.out.println("设置属性中");
            // 控制计算机，先获取权限,引用Tool工具
            Toolkit arTool = Toolkit.getDefaultToolkit();
            System.out.println("获取权限中");
            // 获取对方的屏幕大小
            Dimension size = arTool.getScreenSize();
            double width = size.getWidth(); // 宽
            double height = size.getHeight(); // 高
            System.out.println("获取对方屏幕大小中");
            // 创建新面板
            JLabel ca1 = new JLabel();
            System.out.println("创建新面板中");
            // 添加面板
            c1.add(ca1);
            System.out.println("添加面板中");
            // 尝试
            System.out.println("尝试中");
            try {
                // 召唤机器人
                Robot r1 = new Robot();
                System.out.println("召唤机器人中");
                // 添加正方形
                Rectangle re1 = new Rectangle(c1.getWidth(), 0, (int) width, (int) height);
                System.out.println("添加正方形中中");
                int stu = 0;
                int sui = 0;
                int suo = 0;
                while (stu == 0) {
                    // 截屏
                    BufferedImage img1 = r1.createScreenCapture(re1);
                    while (sui == 0) {
                        System.out.println("截屏中");
                        sui = 1;
                        System.out.println("截屏完毕");
                        System.out.println("截屏将持续进行");
                        System.out.println("退出程序将释放所有内存");
                    }
                    // 添加屏幕
                    ca1.setIcon(new ImageIcon(img1));
                    while (suo == 0) {
                        System.out.println("添加屏幕中");
                        suo = 1;
                        System.out.println("添加屏幕完毕");
                        System.out.println("添加屏幕将持续进行");
                        System.out.println("退出程序将释放所有内存");
                    }
                }
            } catch (AWTException e) {
                System.out.println("未知的异常");
                e.printStackTrace();
            }
        } catch (RuntimeException e) {
            e.printStackTrace();
            System.out.println("未知的异常");
        }
    }
}
