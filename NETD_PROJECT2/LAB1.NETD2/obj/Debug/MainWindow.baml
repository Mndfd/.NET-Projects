   M S B A M L   `   `   `  ????E  ALAB1.NETD2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LAB1.NETD2
LAB1.NETD2  5   	       Lab1Netd.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LAB1.NETD2     5   	     ? Title$&   Incorporeal Incorporated Payroll??5   	    ? WindowStartupLocation$ CenterScreen=?5	   	   $	??500??5
   	   $	??500??6   $	??700??5   	   $	??700??6    ? Icon$ IncIncLogo.png??5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??351* ?6   ?? 5      $
??241* ?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   .+?5   
   ?? -   5         ??Name$ tabControlInterface??5      $??2??62   .@?5      ?? -   5         ??Name$ tabPayrollEntry??5      $??Payroll Entry??6/    ? ToolTip$- 'Click to display the Payroll interface.??6F   .??5       ?  5!      ?? 5"      $??1 ?6+   ?? 5#      $??0 ?6+   ?? 5%      $
??300* ?6+   ?? 5&      $	??250 ?6+   ?? 5'      $
??241* ?6+   ?? 5(      $??0* ?6+    5.      ?? 5/      $	??57* ?6(   ?? 51      $	??57* ?6(   ?? 52      $	??45* ?6(   ?? 53      $	??28* ?6(   .+?5;      ?? $??Worker First _Name:??6   $??
0,45,10,37q?6:   $??Right=?6N   $??Center=?6j   $??0??6?    J? RenderTransformOrigin$ 0.5,0.5&?6?   $??32??6?   $	??176??6?   $??2??6?   ??. $??0??6  	 ?? Target	 6?   ?? 
 ?? ElementName$
 textBoxWorkerName??z?5<      V? 5=      .~?5>   "   ?? ?? 5?   "   ?? 5@   "   T? 5A   "   5B      5D      ?? 5E      $??Worker's _Last Name??6   $??0,82,5,0q?6;   $??Right=?6M   $??Center=?6i   $	??182??6?   $??32??6?   ??. $??2??6?   $??2??6?   $ 	0.5,1.562&?6?   ?? 5F      -   5         ??Name$ txtWorkerName??5F      $??3??65   
???   ?$
??Left=?6Y   $??
30,52,0,44q?6t   $??Stretch=?6?   $	??200??6?   $??0??6?   $  Displays the worker's name??6?   $??1??6?   ?? 5G      -   5        $ txtWorkerLastName??5G      $??3??69   
???   ?$
??Left=?6]   $??
30,86,0,10q?6x   $??Stretch=?6?   $	??200??6?   $??0??6?   $% Displays the worker's last name??6?   $??3??6?   ?? 5H      -   5        $ txtMessagesSent??5H      $??3??67   
???   ?$
??Left=?6[   $??
30,40,0,56q?6v   $??Stretch=?6?   $	??200??6?   $??1??6?   $. (Displays the messages sent by the worker??6?   $??5??6?   ?? 5I      -   5        $ txtEmployeesPay??5I      $??3??67   $
??Left=?6G   $??
30,34,0,62q?6b   $??Stretch=?6v   $	??200??6?   $??2??6?   $' !Displays the Employee's total pay??6?    ?? 
IsReadOnly . ??.  6?   ?? 5N      $??Messages _Sent??6   $??	0,40,5,42q?66   $??Right=?6I   $??Center=?6e   $??1??6?   $	??182??6?   $??32??6?   ??. $??4??6?   $??2??6?   ?? 5O      $??Employee pay??6   $??	0,38,0,46q?63   $??Right=?6F   $??Center=?6b   $	??187??6}   $??2??6?   $??32??6?   ??. $??6??6?   $??3??6?   ?? 5P      -   5         ??Name$ btnCalculate??5P      $??
_Calculate??64   $??Stretch=?6I   $??Stretch=?6g   $??2??6?   $??5,92,5,5q?6?   $??2??6?   $??7??6?    ?? 	IsDefault . $( "Calculate button for employee pay.??6?   $??2??6  $ 0.5,0.5&?6(  ?? 5Q      -   5        $ btnClear??5Q      $??C_lear??6/   $??Stretch=?6@   $??Stretch=?6^   $??3??6z   $??5,92,5,5q?6?   $??2??6?   $??8??6?   $M GButton Clear will clear textboxes and will enable the calcualte button.??6?   $??2??6  ?? 5S      -	   5         ??Name$ labelNameError??5S      $??4??65   $??Stretch=?6E   $??5q?6c   $??Center=?6n   $??Stretch=?6?   
???  ??6?   ?? 5T      -
   5        $ labelMessagesError??5T      $??Center=?68   $??4??6[   $??1??6k   $??Stretch=?6x   $??5q?6?   $??Stretch=?6?   
???  ??6?   ?? 5U      -   5        $ labelEmployeesError??5U      $??4??6:   $??2??6J   $??Stretch=?6W   $??5q?6u   $??Stretch=?6?   
???  ??6?   5V      5Z      ?? 5[      -   5        $ 
tabSummary??5[      $??Summary??6*   $- 'Click to display the summary interface.??6;   .??5_      ? $??
10,0,-10,0q?6    5`      ?? 5a      $
??311* ?6+   ?? 5b      $
??459* ?6+    5d      ?? 5e      ?? 5f      ?? 5g      ?? 5h      ?? 5i      .+?5l      ?? $??Total Workers:??6   $??
0,17,62,15q?65   $??Right=?6I   $??Center=?6e   $??26??6?   $??85??6?   $ -0.057,0.814&?6?   ??. $??0??6?   ?? 5m      -   5        $ txtTotalWorkers??5m      $??1??67   $
??Left=?6G   $??
22,17,0,23q?6b   $??Center=?6v   $	??200??6?    . $2 ,Displays the total number of entered workers??6?   $??18??6?   $??1??6?   ?? 5r      $??
Total Pay:??6   $??
0,17,88,15q?61   $??Right=?6E   $??Center=?6a   $??1??6|   $??26??6?   $??59??6?   ??. $??2??6?   ?? 5s      -   5        $ txtTotalPay??5s      $??1??63   $
??Left=?6C   $??
22,25,0,15q?6^   $??Center=?6r   $	??200??6?   $??1??6?    . $- 'Display the total pay among all workers??6?   $??18??6?   $??3??6?   ?? 5x      $??Average Pay:??6   $??
0,12,70,20q?63   $??Right=?6G   $??Center=?6c   $??3??6~   $??26??6?   $??77??6?   ??. $??6??6?   ?? 5y      -   5        $ txtAveragePay??5y      $??1??65   $
??Left=?6E   $??
22,20,0,20q?6`   $??Center=?6t   $	??200??6?   $??3??6?    . $0 *Displays the average pay among all workers??6?   $??18??6?   $??7??6?   ?? 5z      $??Total Messages: ??6   $
??Left=?68   $??
90,12,0,20q?6S   $??2??6g   $??Center=?6t   ??. $??4??6?   ?? 5{      -   5        $ txtTotalMessages??5{      $??1??68   $
??Left=?6H   $??
22,20,0,20q?6c   $??Center=?6w   $	??200??6?   $??2??6?    . $/ )Displays the total messages among workers??6?   $??18??6?   $??5??6?   5|      5      ?? 5?      -   5        $ tabEmployeeList??5?      $??Employee List??6/   .??5?      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridEmployees??5?         
IsReadOnly . 66   5?      5?      ?? 5?   
   -   5        $ 
buttonExit??5?      $??E_xit??6%   $
??10,4q?65   $??1??6C   $) #Click here to exit the application.??6P   $??2??6~   $??9??6?   ?? 5?   
   -   5         ??Name$ 
statusArea??5?      $??2??6(   $??2??65   .@?5?      ?? $
??Left=?6   $??Center=?67   .??5?      ?? -   5        $ labelStatus??5?      $??Current Status:??6-   5?      ?? 5?      $??Right=?6   $??Center=?68   .??5?      ?? -   5        $ 	labelTime??5?      5?      5?      5?      5?      