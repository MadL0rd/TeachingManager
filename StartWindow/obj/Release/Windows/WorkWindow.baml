   M S B A M L   `   `   `  ���� I  ETeacingManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:StartWindowStartWindow  3clr-namespace:StartWindow.DataStartWindow.Data  =#clr-namespace:StartWindow.ViewModelStartWindow.ViewModel      StartWindow.WorkWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:StartWindow     /Dataclr-namespace:StartWindow.Data     9	ViewModel#clr-namespace:StartWindow.ViewModel       � Title$  TeacingManager��$��528.5��$��880.5�� � WindowStartupLocation$ CenterScreen=� � 	Resources +   %StartWindow.Data.AducationBaseDataSet   aducationBaseDataSet��%   &	           � DataContext *  $StartWindow.ViewModel.TasksViewModel  .��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF5F0041�� � Offset$ 0Q�� $ 	#FFE6B2D6��$ 1Q� � ColumnDefinitions �� $	��190 ��� .+�� $y�Visible=�$��2��	 J� Opacity$		 0.7Q�
 J� Effect
 -  'System.Windows.Media.Effects.BlurEffect  ����  �� ImageSource$K E/TeacingManager;component/a-abstract_pink_gradient_gradient-30993.jpg���� $��0�����	#7FA0A0A0$��0,42,0,0q�.+��� -   $!��Выдать задание��$��40��
�������$��16(�$��2q�
����������	#60AA4030�� -   $%��Просмотр заданий��$��40��
�������$��16(�$��2q�
����������	#60AA4030�� -   $%��Проверка ответов��$��40��
�������$��16(�$��2q�
����������	#60AA4030�� -   $��Журнал��$��40��
�������$��16(�$��2q�
����������	#60AA4030� -    �Name$ MarkGrid��$	��220��$y�	Collapsed=�.+�� ���	#7FA0A0A0$��10,23,10,10q�.+��� $��Оценка��$
��Wrap=�$	��170��$��16(�
�������$��20��$	��Top=�$
��Left=�$��
10,0,-10,0q��� $��Комментарий��$
��Wrap=�$	��170��$��16(�
�������$��20��$	��Top=�$
��Left=�$��10,47,-10,0q��� -    ��Name$ MarkComboBox��$
��Left=�$��	10,25,0,0q�$	��Top=�$	��120������ $	 0,1&�$	 0,0&�.��� $ 	#FFF0F0F0��$ 0Q�� $ 	#7FFFFFFF��$ 1Q�.@��� $��5���� $��4���� $��3���� $��2���� $��1���� -    ��Name$ 
CommentBox��$��10,72,10,10q����	#80FFFFFF�� -   $ 	UsrIDBuff��$y�Hidden=�$	��130������ *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=��� -	    ��Name$ HalloBox��$5��/     Текущий пользователь - ��$��42��$
��Wrap=�$	��Top=�$��Century Schoolbook)�$��22(�
������� �� TextAlignment$ Center=����	#7FA0A0A0$��2���� $� ���� -
    ��Name$ Avatar��$"��shkolnaya-doska-zelenaya.png��$��1��$��42��$	��Top=�$��Right=�$��42��
   � -   $ GiveTaskGrid��$y�Hidden=�$��1��$��0,50,0,0q� � RowDefinitions �� $
��283* ��� $
��124* ��� $	��40* �.+�� -   $ KlassChoice��$
��Left=�$��0,9,0,0q�$	��Top=�$	��174��$��32�� �� $
��Auto �$	��171���� $
��Auto �$��3�� �� $
��Auto �.+��� -   $ KlassComboBox��$��	71,5,25,0q�$	��Top=�$��22������ *ItemsUsrKlass+�� $��Класс:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� � -   $ SubjectChoice��$
��Left=�$��	143,9,0,0q�$	��Top=�$	��265��$��32�� �� $
��Auto �.+��� -   $ SubjectComboBox��$��	81,5,17,0q�$	��Top=�$��22������ *ItemsUsrSubjects+�� $��Предмет:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� � -   $ 
DateChoice��$
��Left=�$��
414,10,0,0q�$	��Top=�$	��265��$��37�� �� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��Дата сдачи:��$��0��$
��Left=�$��3,-3,0,9q�$��0��$��Center=�
�������$��16(���Z� (  "System.Windows.Controls.DatePicker  -     Name$ DatePic�� J� RenderTransformOrigin$ 1.1,0.5&�$��
0,1,-160,2q�$��Right=�$	��160��$��1��$��14(��� -   $ TitleBox��$��27��$��
10,75,10,0q� �� TextWrapping$
 Wrap=�$	��Top=����	#7FA0A0A0$��14(�
��������� $
��Left=�$��	10,47,0,0q�$
��Wrap=�$��	Тема:��$	��Top=�$��89��$��28��
�������$��16(��� -   $ TaskText�� �� AcceptsReturn . $��10,130,10,9q����	#7FA0A0A0 �� SelectionBrush �	#7F0078D7$��14(�
���������Z� �� $
��Left=�$��
10,105,0,0q�$
��Wrap=�$ ��Текст задания:��$	��Top=�$	��230��$��25��$��16(�
��������� -   $��Отправить��$��183,0,183,13q�$��1��$��2��$��29��$��Bottom=��� -   $��Выбрать файл��$
��Left=�$��5,5,0,5q�$	��108��$��1���� -    ��Name$ DopFilesListView��$��	118,5,5,5q����	#7FA0A0A0
�������$��1������ *ItemsTaskFiles+ �� Mode$ TwoWay=���Z� ���� .R�� ���� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType" �� � 	ItemWidth �� *(ListView.View).ItemWidth+ �� " ������ *	ItemWidth+ �� *Self+ � 
ItemHeight �� *(ListView.View).ItemHeight+ �� " ������ .R��� -   $	��100��$	��100������ *IMGS+� -   $ TasksViewGrid��$y�Hidden=�$��1��$��0,50,0,0q� �� $
��auto ��� .+��� -   $ TaskViewList��$��1��$��20,11,10,19q����	#7FA0A0A0
���������.  ���� *Items+$ TwoWay=����� .R���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� $��30,5,5,5q�$��50��$��16(����� *Klass+�� $��5q�$	��100��$��16(����� *	Subject+�� $��5q�$	��160��$��16(����� *Title+�� $��5q�$��16(����� *DateBeginStr+�� $��-��$��2q�$��16(��� $��5q�$��16(����� *
DateEndStr+9� $��	0,-23,0,0q�.���� $ Vertical=�.+��� $��	5,20,5,30q�
�������$��16(����� *
TaskText+�� -   $
��Auto��$
��Auto��$	��100��$	��100��$��5q�$
��Left=����� *IMGS+  � ToolTip$5  /Нажмите, чтобы посмотреть���� -   $��Проверить��$��14(�� -   $ KlassChoice_Copy��$
��Left=�$��62,6,0,0q�$	��Top=�$	��174��$��32��$��2�� �� $
��Auto �$	��171���� $
��Auto �$��3�� �� $
��Auto �.+��� -   $ KlassComboBox1��$��	71,5,25,0q�$	��Top=�$��22������ *ItemsUsrKlass+! �� Text! �� *KlassFilter+�� $��Класс:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� � -   $ SubjectChoice_Copy��$
��Left=�$��	204,6,0,0q�$	��Top=�$	��266��$��32��$��2�� �� $
��Auto �.+��� -   $ SubjectComboBox1��$��	81,5,17,0q�$	��Top=�$��22��! �� *SubjectFilter+���� *ItemsUsrSubjects+�� $��Предмет:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� �� -    $��Сброс фильтра��$
��Left=�$��
474,10,0,0q�$	��Top=�$	��128��$��22��� -!   $ 
AnswerGrid��$y�Hidden=�$��1��$��0,42,0,0q�.+��� $��Задание��$��10,0,0,0q�$
��Wrap=�$	��230��$��16(�
�������$��20��$	��Top=�$
��Left=��� -"   $ CurrentTaskView��$��
10,25,10,0q����	#7FA0A0A0
���������.  $	��150��$	��Top=����� *CurrentTaskItem+$ TwoWay=����� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��30,5,5,5q�$��16(����� *Klass+�� $��5q�$��16(����� *	Subject+�� $��5q�$��16(����� *Title+�� $��5q�$��16(����� *DateBeginStr+�� $��-��$��2q�$��16(��� $��5q�$��16(����� *
DateEndStr+�� $ Vertical=�.+��� $��	5,20,5,30q�
�������$��16(����� *
TaskText+�� -#   $
��Auto��$
��Auto��$	��100��$	��100��$��5q�$
��Left=����� *IMGS+$5  /Нажмите, чтобы посмотреть���� $y�	Collapsed=�$ ��Редактировать��$��14(��� $��Ответы��$��
10,175,0,0q�$
��Wrap=�$	��230��$��16(�
�������$��20��$	��Top=�$
��Left=��� -$   $ CurrentTaskAnswerView��$��10,200,10,10q����	#7FA0A0A0
���������.  ���� *CurrentTaskAnswersItem+$ TwoWay=����� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��5q�$��16(����� *	DateStr+�� $��5q�$��16(����� *
StudentFIO+�� $��Оценка:��$��30,5,5,5q�$��16(��� $��5q�$��16(����	#FFAFFF81���� *Mark+��Z� �� $��5q�$��16(����� *	Comment+�� $ Vertical=�.+��� $��5q�
�������$��16(����� *
AnswerText+�� -%   $
��Auto��$
��Auto��$	��100��$	��100��$��5q�$
��Left=����� *IMGS+$5  /Нажмите, чтобы посмотреть���� -&   $y�Visible=�$��	100,0,0,0q�$	��200��$��Оценить��$��14(�$
��Left=�� -'   $ JournalGrid��$y�Hidden=�$��1��$��0,42,0,0q�.+�� -(   $ KlassChoice_Copy1��$
��Left=�$��0,9,0,0q�$	��Top=�$	��174��$��32�� �� $
��Auto �$	��171���� $
��Auto �$��3�� �� $
��Auto �.+��� -)   $ JKlassComboBox��$��	71,5,25,0q�$	��Top=�$��22������ *ItemsUsrKlass+�� $��Класс:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� � -*   $ SubjectChoice_Copy1��$
��Left=�$��	143,9,0,0q�$	��Top=�$	��265��$��32�� �� $
��Auto �.+��� -+   $ JSubjectComboBox��$��	81,5,17,0q�$	��Top=�$��22������ *ItemsUsrSubjects+�� $��Предмет:��$��0��$
��Left=�$��3,-2,0,3q�$��0��$��Center=�$��31��$��77��
�������$��16(���Z� �� -,   $��Обновить��$��413,14,132,0q�$��22��$	��Top=��� --   " ��Name$" PrintButton��{�.  $��Распечатать��$��	0,14,10,0q�$��22��$	��Top=�$��Right=�$	��102��&   System.Windows.Controls.DataGrid  -.   #  Name$# JournalDataGrid��$��10,50,10,10q�$��16(����	#99F0F0F0� -/   $ ImageViewGrid��$y�Hidden=����	#7FA0A0A0$��2��.+��� -0   $ ImageForView��