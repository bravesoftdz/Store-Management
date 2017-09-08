using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private double h;
        private double w;

        private int SelectedID;


        private TextBlock nomePessoa;
        private TextBlock Genero;
        private TextBlock loja;
        private TextBlock morada;
        private TextBlock contactoTB;
        private TextBlock ans3;
        private TextBlock ans4;
        private Viewbox view3;
        private Viewbox view4;

        private TextBox answernif;
        private TextBox answerNomePessoa;
        private TextBox answerGenero;
        private TextBox answerBIPessoa;
        private TextBox answerNIFPessoa;
        private TextBox answerDiaNascimento;
        private TextBox answerMesNascimento;
        private TextBox answerAnoNascimento;
        private TextBox answerMorada;
        private TextBox answerContacto;
        private TextBox answerMail;
        private TextBox answerCargoPessoa;
        private TextBox answerSalario;
        private TextBox answerNIB;
        private TextBox answerPassword;
        private TextBox answerNomeLoja;
        private TextBox answerContactoLoja;
        private TextBox answerMoradaLoja;
        private TextBox answer1Update;
        private TextBox answer2Update;
        private TextBox answer3Update;
        private TextBox answer4Update;

        private ToggleButton activeButton;
        private Button updatePessoa;
        private Button editPessoa;

        public Settings()
        {
            InitializeComponent();
            initializeWindow();
        }

        private void initializeWindow()
        {
            h = MainWindow.window.myWindow.getHeight();
            w = MainWindow.window.myWindow.getWidth();

            initializeLeftAndTopBar();

            activeButton = addFuncionario;

            initializeAddPessoa();

            initializeAddFuncionario();

            initializeAddShop();

            InitializeList();
            scrollSet("", Visibility.Hidden, false);
            ScrollerInfo.Visibility = Visibility.Hidden;
            ScrollerPessoas.Visibility = Visibility.Hidden;
            ScrollerGerentes.Visibility = Visibility.Hidden;

            
        }


        private void InitializeList()
        {
            //Voltar a ver

            scrollSet("", Visibility.Hidden, false);
            ScrollerPessoas.Height = h * 0.668;
            ScrollerPessoas.Width = w * 0.33;
            Canvas.SetTop(ScrollerPessoas, h * 0.185);
            Canvas.SetLeft(ScrollerPessoas, w * 0.35);

            PessoasGrid.ColumnWidth = w * 0.075;

            ChangeInfo.Visibility = Visibility.Hidden;
            ChangeInfo.Height = h * 0.35;
            ChangeInfo.Width = w * 0.25;

            Canvas.SetTop(ChangeInfo, h * 0.3);
            Canvas.SetLeft(ChangeInfo, w * 0.65);

            Viewbox view1 = new Viewbox();
            setSizePositionViewBox(view1, 0.03, 0.1, 0.03, 0.007);
            ChangeInfo.Children.Add(view1);

            TextBlock ans1 = new TextBlock();
            ans1.Text = "Nome:";
            ans1.TextAlignment = TextAlignment.Justify;
            ans1.TextTrimming = TextTrimming.CharacterEllipsis;
            view1.Child = ans1;

            answer1Update = new TextBox();
            answer1Update.FontSize = 18;
            answer1Update.BorderBrush = Brushes.Gray;
            answer1Update.BorderThickness = new Thickness(w * 0.001);
            answer1Update.IsEnabled = false;
            setSizePositionTextBox(answer1Update, 0.03, 0.14, 0.03, 0.105);
            ChangeInfo.Children.Add(answer1Update);

            Viewbox view2 = new Viewbox();
            setSizePositionViewBox(view2, 0.03, 0.1, 0.08, 0.015);
            ChangeInfo.Children.Add(view2);

            TextBlock ans2 = new TextBlock();
            ans2.Text = "Contacto:";
            ans2.TextAlignment = TextAlignment.Justify;
            ans2.TextTrimming = TextTrimming.CharacterEllipsis;
            view2.Child = ans2;

            answer2Update = new TextBox();
            answer2Update.FontSize = 18;
            answer2Update.BorderBrush = Brushes.Red;
            answer2Update.BorderThickness = new Thickness(w * 0.001);
            answer2Update.IsEnabled = false;
            setSizePositionTextBox(answer2Update, 0.03, 0.14, 0.08, 0.105);
            ChangeInfo.Children.Add(answer2Update);

            answer2Update.TextChanged += answer2Update_TextChanged;

            view3 = new Viewbox();
            setSizePositionViewBox(view3, 0.03, 0.1, 0.13, 0.015);
            ChangeInfo.Children.Add(view3);

            ans3 = new TextBlock();
            ans3.Text = "Contacto:";
            ans3.TextAlignment = TextAlignment.Justify;
            ans3.TextTrimming = TextTrimming.CharacterEllipsis;
            view3.Child = ans3;

            answer3Update = new TextBox();
            answer3Update.FontSize = 18;
            answer3Update.BorderBrush = Brushes.Red;
            answer3Update.BorderThickness = new Thickness(w * 0.001);
            answer3Update.IsEnabled = false;
            setSizePositionTextBox(answer3Update, 0.03, 0.14, 0.13, 0.105);
            ChangeInfo.Children.Add(answer3Update);

            answer3Update.TextChanged += answer3Update_TextChanged;

            view4 = new Viewbox();
            setSizePositionViewBox(view4, 0.03, 0.1, 0.18, 0.015);
            ChangeInfo.Children.Add(view4);

            ans4 = new TextBlock();
            ans4.Text = "Form4:";
            ans4.TextAlignment = TextAlignment.Justify;
            ans4.TextTrimming = TextTrimming.CharacterEllipsis;
            view4.Child = ans4;

            answer4Update = new TextBox();
            answer4Update.FontSize = 18;
            answer4Update.BorderBrush = Brushes.Red;
            answer4Update.BorderThickness = new Thickness(w * 0.001);
            answer4Update.IsEnabled = false;
            setSizePositionTextBox(answer4Update, 0.03, 0.14, 0.18, 0.105);
            ChangeInfo.Children.Add(answer4Update);

            answer4Update.TextChanged += answer4Update_TextChanged;
            
            editPessoa = new Button();
            editPessoa.Width = w * 0.06;
            editPessoa.Height = h * 0.04;
            Canvas.SetTop(editPessoa, h * 0.26);
            Canvas.SetLeft(editPessoa, w * 0.17);

            BitmapImage bitmap1 = new BitmapImage();
            Image img1 = new Image();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri("/WpfApplication3;component/Images/Buttons/Forms/Editar.png", UriKind.Relative);
            bitmap1.EndInit();
            img1.Stretch = Stretch.Fill;
            img1.Source = bitmap1;
            editPessoa.Content = img1;
            editPessoa.Background = new ImageBrush(bitmap1);

            ChangeInfo.Children.Add(editPessoa);
            editPessoa.Click += editarPessoaCLICK;

            updatePessoa = new Button();
            updatePessoa.Width = w * 0.06;
            updatePessoa.Height = h * 0.04;
            Canvas.SetTop(updatePessoa, h * 0.26);
            Canvas.SetLeft(updatePessoa, w * 0.17);

            BitmapImage bitmap = new BitmapImage();
            Image img = new Image();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/WpfApplication3;component/Images/Buttons/Forms/Guardar.png", UriKind.Relative);
            bitmap.EndInit();
            img.Stretch = Stretch.Fill;
            img.Source = bitmap;
            updatePessoa.Content = img;
            updatePessoa.Background = new ImageBrush(bitmap);

            ChangeInfo.Children.Add(updatePessoa);
            updatePessoa.Click += updatePessoaCLICK;
            updatePessoa.Visibility = Visibility.Hidden;
            updatePessoa.IsEnabled = false;

            Button removePessoa = new Button();
            removePessoa.Width = w * 0.06;
            removePessoa.Height = h * 0.04;
            Canvas.SetTop(removePessoa, h * 0.26);
            Canvas.SetLeft(removePessoa, w * 0.06);

            BitmapImage bitmap2 = new BitmapImage();
            Image img2 = new Image();
            bitmap2.BeginInit();
            bitmap2.UriSource = new Uri("/WpfApplication3;component/Images/Buttons/Forms/Remover.png", UriKind.Relative);
            bitmap2.EndInit();
            img2.Stretch = Stretch.Fill;
            img2.Source = bitmap2;
            removePessoa.Content = img2;
            removePessoa.Background = new ImageBrush(bitmap2);

            ChangeInfo.Children.Add(removePessoa);
            removePessoa.Click += removePessoaCLICK;

        }

        private void initializeAddPessoa()
        {
            AddPessoa.Visibility = Visibility.Visible;

            AddPessoa.Height = h * 0.45;
            AddPessoa.Width = w * 0.35;
            Canvas.SetTop(AddPessoa, h * 0.3);
            Canvas.SetLeft(AddPessoa, w * 0.43);

            Viewbox viewAddPessoa = new Viewbox();
            setSizePositionViewBox(viewAddPessoa, 0.03, 0.1, -0.03, 0.015);
            AddPessoa.Children.Add(viewAddPessoa);

            nomePessoa = new TextBlock();
            nomePessoa.Text = "Nome:";
            nomePessoa.TextAlignment = TextAlignment.Justify;
            nomePessoa.TextTrimming = TextTrimming.CharacterEllipsis;
            viewAddPessoa.Child = nomePessoa;

            answerNomePessoa = new TextBox();
            answerNomePessoa.FontSize = 18;
            answerNomePessoa.BorderBrush = Brushes.Red;
            answerNomePessoa.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerNomePessoa, 0.03, 0.14, -0.03, 0.16);
            AddPessoa.Children.Add(answerNomePessoa);

            answerNomePessoa.TextChanged += answerNomePessoa_TextChanged;

            Viewbox viewAddGenero = new Viewbox();
            setSizePositionViewBox(viewAddGenero, 0.03, 0.1, 0.03, 0.015);
            AddPessoa.Children.Add(viewAddGenero);

            Genero = new TextBlock();
            Genero.Text = "Genero:";
            Genero.TextAlignment = TextAlignment.Justify;
            Genero.TextTrimming = TextTrimming.CharacterEllipsis;
            viewAddGenero.Child = Genero;

            answerGenero = new TextBox();
            answerGenero.FontSize = 18;
            answerGenero.BorderBrush = Brushes.Red;
            answerGenero.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerGenero, 0.03, 0.14, 0.03, 0.16);
            AddPessoa.Children.Add(answerGenero);

            answerGenero.TextChanged += answerGenero_TextChanged;


            Viewbox viewBIPessoa = new Viewbox();
            setSizePositionViewBox(viewBIPessoa, 0.03, 0.045, 0.08, 0.03);
            AddPessoa.Children.Add(viewBIPessoa);

            TextBlock biPessoa = new TextBlock();
            biPessoa.Text = "BI:";
            biPessoa.TextAlignment = TextAlignment.Justify;
            biPessoa.TextTrimming = TextTrimming.CharacterEllipsis;
            viewBIPessoa.Child = biPessoa;

            answerBIPessoa = new TextBox();
            answerBIPessoa.FontSize = 18;
            answerBIPessoa.BorderBrush = Brushes.Red;
            answerBIPessoa.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerBIPessoa, 0.03, 0.14, 0.08, 0.16);
            AddPessoa.Children.Add(answerBIPessoa);

            answerBIPessoa.TextChanged += answerBIPessoa_TextChanged;

            Viewbox viewNIFPessoa = new Viewbox();
            setSizePositionViewBox(viewNIFPessoa, 0.03, 0.045, 0.13, 0.034);
            AddPessoa.Children.Add(viewNIFPessoa);

            TextBlock nifPessoa = new TextBlock();
            nifPessoa.Text = "NIF:";
            nifPessoa.TextAlignment = TextAlignment.Justify;
            nifPessoa.TextTrimming = TextTrimming.CharacterEllipsis;
            viewNIFPessoa.Child = nifPessoa;

            answerNIFPessoa = new TextBox();
            answerNIFPessoa.FontSize = 18;
            answerNIFPessoa.BorderBrush = Brushes.Red;
            answerNIFPessoa.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerNIFPessoa, 0.03, 0.14, 0.13, 0.16);
            AddPessoa.Children.Add(answerNIFPessoa);

            answerNIFPessoa.TextChanged += answerNIFPessoa_TextChanged;

            Viewbox viewDataNascimento = new Viewbox();
            setSizePositionViewBox(viewDataNascimento, 0.03, 0.1, 0.18, 0.045);
            AddPessoa.Children.Add(viewDataNascimento);

            TextBlock dataNascimento = new TextBlock();
            dataNascimento.Text = "Data Nascimento:";
            dataNascimento.TextAlignment = TextAlignment.Justify;
            dataNascimento.TextTrimming = TextTrimming.CharacterEllipsis;
            viewDataNascimento.Child = dataNascimento;

            answerDiaNascimento = new TextBox();
            answerDiaNascimento.FontSize = 18;
            answerDiaNascimento.BorderBrush = Brushes.Red;
            answerDiaNascimento.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerDiaNascimento, 0.03, 0.03, 0.18, 0.16);
            AddPessoa.Children.Add(answerDiaNascimento);

            answerDiaNascimento.TextChanged += answerDiaNascimento_TextChanged;

            answerMesNascimento = new TextBox();
            answerMesNascimento.FontSize = 18;
            answerMesNascimento.BorderBrush = Brushes.Red;
            answerMesNascimento.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerMesNascimento, 0.03, 0.03, 0.18, 0.2);
            AddPessoa.Children.Add(answerMesNascimento);

            answerMesNascimento.TextChanged += answerMesNascimento_TextChanged;

            answerAnoNascimento = new TextBox();
            answerAnoNascimento.FontSize = 18;
            answerAnoNascimento.BorderBrush = Brushes.Red;
            answerAnoNascimento.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerAnoNascimento, 0.03, 0.06, 0.18, 0.24);
            AddPessoa.Children.Add(answerAnoNascimento);

            answerAnoNascimento.TextChanged += answerAnoNascimento_TextChanged;

            Viewbox viewContact = new Viewbox();
            setSizePositionViewBox(viewContact, 0.03, 0.1, 0.23, 0.018);
            AddPessoa.Children.Add(viewContact);

            TextBlock morada = new TextBlock();
            morada.Text = "Morada:";
            morada.TextAlignment = TextAlignment.Justify;
            morada.TextTrimming = TextTrimming.CharacterEllipsis;
            viewContact.Child = morada;

            answerMorada = new TextBox();
            answerMorada.FontSize = 18;
            answerMorada.BorderBrush = Brushes.Red;
            answerMorada.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerMorada, 0.03, 0.14, 0.23, 0.16);
            AddPessoa.Children.Add(answerMorada);

            answerMorada.TextChanged += answerMorada_TextChanged;

            Viewbox viewContactoPessoa = new Viewbox();
            setSizePositionViewBox(viewContactoPessoa, 0.03, 0.1, 0.28, 0.022);
            AddPessoa.Children.Add(viewContactoPessoa);

            TextBlock contacto = new TextBlock();
            contacto.Text = "Contacto:";
            contacto.TextAlignment = TextAlignment.Justify;
            contacto.TextTrimming = TextTrimming.CharacterEllipsis;
            viewContactoPessoa.Child = contacto;

            answerContacto = new TextBox();
            answerContacto.FontSize = 18;
            answerContacto.BorderBrush = Brushes.Red;
            answerContacto.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerContacto, 0.03, 0.14, 0.28, 0.16);
            AddPessoa.Children.Add(answerContacto);

            answerContacto.TextChanged += answerContacto_TextChanged;

            Viewbox viewEmailPessoa = new Viewbox();
            setSizePositionViewBox(viewEmailPessoa, 0.03, 0.1, 0.33, 0.012);
            AddPessoa.Children.Add(viewEmailPessoa);

            TextBlock mail = new TextBlock();
            mail.Text = "Email:";
            mail.TextAlignment = TextAlignment.Justify;
            mail.TextTrimming = TextTrimming.CharacterEllipsis;
            viewEmailPessoa.Child = mail;

            answerMail = new TextBox();
            answerMail.FontSize = 18;
            answerMail.BorderBrush = Brushes.Red;
            answerMail.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerMail, 0.03, 0.14, 0.33, 0.16);
            AddPessoa.Children.Add(answerMail);

            answerMail.TextChanged += answerMail_TextChanged;


            Button addPessoa = new Button();
            addPessoa.IsDefault = true;
            addPessoa.Width = w * 0.06;
            addPessoa.Height = h * 0.04;
            Canvas.SetTop(addPessoa, h * 0.38);
            Canvas.SetLeft(addPessoa, w * 0.27);

            BitmapImage bitmap = new BitmapImage();
            Image img = new Image();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/WpfApplication3;component/Images/Buttons/Forms/Adicionar.png", UriKind.Relative);
            bitmap.EndInit();
            img.Stretch = Stretch.Fill;
            img.Source = bitmap;
            addPessoa.Content = img;
            addPessoa.Background = new ImageBrush(bitmap);

            AddPessoa.Children.Add(addPessoa);
            addPessoa.Click += addPessoaCLICK;

        }

        private void initializeAddFuncionario()
        {
            AddFuncionario.Visibility = Visibility.Hidden;

            AddFuncionario.Height = h * 0.3;
            AddFuncionario.Width = w * 0.35;
            Canvas.SetTop(AddFuncionario, h * 0.35);
            Canvas.SetLeft(AddFuncionario, w * 0.43);

            Viewbox viewCargo = new Viewbox();
            setSizePositionViewBox(viewCargo, 0.03, 0.045, 0.03, 0.05);
            AddFuncionario.Children.Add(viewCargo);

            TextBlock cargoPessoa = new TextBlock();
            cargoPessoa.Text = "Cargo:";
            cargoPessoa.TextAlignment = TextAlignment.Justify;
            cargoPessoa.TextTrimming = TextTrimming.CharacterEllipsis;
            viewCargo.Child = cargoPessoa;

            answerCargoPessoa = new TextBox();
            answerCargoPessoa.FontSize = 18;
            answerCargoPessoa.BorderBrush = Brushes.Red;
            answerCargoPessoa.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerCargoPessoa, 0.03, 0.14, 0.03, 0.16);
            AddFuncionario.Children.Add(answerCargoPessoa);

            answerCargoPessoa.TextChanged += answerCargoPessoa_TextChanged;

            Viewbox viewSalario = new Viewbox();
            setSizePositionViewBox(viewSalario, 0.03, 0.1, 0.08, 0.025);
            AddFuncionario.Children.Add(viewSalario);

            TextBlock salario = new TextBlock();
            salario.Text = "Salário:";
            salario.TextAlignment = TextAlignment.Justify;
            salario.TextTrimming = TextTrimming.CharacterEllipsis;
            viewSalario.Child = salario;

            answerSalario = new TextBox();
            answerSalario.FontSize = 18;
            answerSalario.BorderBrush = Brushes.Red;
            answerSalario.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerSalario, 0.03, 0.14, 0.08, 0.16);
            AddFuncionario.Children.Add(answerSalario);

            answerSalario.TextChanged += answerSalario_TextChanged;

            Viewbox viewNIB = new Viewbox();
            setSizePositionViewBox(viewNIB, 0.03, 0.1, 0.13, 0.017);
            AddFuncionario.Children.Add(viewNIB);

            TextBlock nib = new TextBlock();
            nib.Text = "NIB:";
            nib.TextAlignment = TextAlignment.Justify;
            nib.TextTrimming = TextTrimming.CharacterEllipsis;
            viewNIB.Child = nib;

            answerNIB = new TextBox();
            answerNIB.FontSize = 18;
            answerNIB.BorderBrush = Brushes.Red;
            answerNIB.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerNIB, 0.03, 0.14, 0.13, 0.16);
            AddFuncionario.Children.Add(answerNIB);

            answerNIB.TextChanged += answerNIB_TextChanged;

            Viewbox viewPassword = new Viewbox();
            setSizePositionViewBox(viewPassword, 0.03, 0.1, 0.18, 0.032);
            AddFuncionario.Children.Add(viewPassword);

            TextBlock password = new TextBlock();
            password.Text = "Password:";
            password.TextAlignment = TextAlignment.Justify;
            password.TextTrimming = TextTrimming.CharacterEllipsis;
            viewPassword.Child = password;

            answerPassword = new TextBox();
            answerPassword.FontSize = 18;
            answerPassword.BorderBrush = Brushes.Red;
            answerPassword.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerPassword, 0.03, 0.14, 0.18, 0.16);
            AddFuncionario.Children.Add(answerPassword);

            answerPassword.TextChanged += answerPassword_TextChanged;

            Button addFuncionario = new Button();
            addFuncionario.IsDefault = true;
            addFuncionario.Width = w * 0.06;
            addFuncionario.Height = h * 0.04;
            Canvas.SetTop(addFuncionario, h * 0.23);
            Canvas.SetLeft(addFuncionario, w * 0.27);

            BitmapImage bitmap = new BitmapImage();
            Image img = new Image();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/WpfApplication3;component/Images/Buttons/Forms/Adicionar.png", UriKind.Relative);
            bitmap.EndInit();
            img.Stretch = Stretch.Fill;
            img.Source = bitmap;
            addFuncionario.Content = img;
            addFuncionario.Background = new ImageBrush(bitmap);

            AddFuncionario.Children.Add(addFuncionario);
            addFuncionario.Click += addFuncionarioCLICK;

        }

        private void initializeAddShop()
        {
            AddLojaC.Visibility = Visibility.Hidden;

            AddLojaC.Height = h * 0.3;
            AddLojaC.Width = w * 0.35;
            Canvas.SetTop(AddLojaC, h * 0.2);
            Canvas.SetLeft(AddLojaC, w * 0.43);

            Viewbox viewLoja = new Viewbox();
            setSizePositionViewBox(viewLoja, 0.03, 0.1, 0.03, 0.016);
            AddLojaC.Children.Add(viewLoja);

            loja = new TextBlock();
            loja.Text = "Nome: ";
            loja.TextAlignment = TextAlignment.Justify;
            loja.TextTrimming = TextTrimming.CharacterEllipsis;
            viewLoja.Child = loja;

            answerNomeLoja = new TextBox();
            answerNomeLoja.FontSize = 18;
            answerNomeLoja.BorderBrush = Brushes.Red;
            answerNomeLoja.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerNomeLoja, 0.03, 0.14, 0.03, 0.16);
            AddLojaC.Children.Add(answerNomeLoja);

            answerNomeLoja.TextChanged += answerNomeLoja_TextChanged;

            Viewbox viewContacto = new Viewbox();
            setSizePositionViewBox(viewContacto, 0.03, 0.1, 0.08, 0.023);
            AddLojaC.Children.Add(viewContacto);

            contactoTB = new TextBlock();
            contactoTB.Text = "Contacto: ";
            contactoTB.TextAlignment = TextAlignment.Justify;
            contactoTB.TextTrimming = TextTrimming.CharacterEllipsis;
            viewContacto.Child = contactoTB;

            answerContactoLoja = new TextBox();
            answerContactoLoja.FontSize = 18;
            answerContactoLoja.BorderBrush = Brushes.Red;
            answerContactoLoja.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerContactoLoja, 0.03, 0.14, 0.08, 0.16);
            AddLojaC.Children.Add(answerContactoLoja);

            answerContactoLoja.TextChanged += answerContactoLoja_TextChanged;

            Viewbox viewMorada = new Viewbox();
            setSizePositionViewBox(viewMorada, 0.03, 0.1, 0.13, 0.02);
            AddLojaC.Children.Add(viewMorada);

            morada = new TextBlock();
            morada.Text = "Morada: ";
            morada.TextAlignment = TextAlignment.Justify;
            morada.TextTrimming = TextTrimming.CharacterEllipsis;
            viewMorada.Child = morada;

            answerMoradaLoja = new TextBox();
            answerMoradaLoja.FontSize = 18;
            answerMoradaLoja.BorderBrush = Brushes.Red;
            answerMoradaLoja.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answerMoradaLoja, 0.03, 0.14, 0.13, 0.16);
            AddLojaC.Children.Add(answerMoradaLoja);

            answerMoradaLoja.TextChanged += answerMoradaLoja_TextChanged;

            Viewbox viewIDGerente = new Viewbox();
            setSizePositionViewBox(viewIDGerente, 0.03, 0.1, 0.18, 0.028);
            AddLojaC.Children.Add(viewIDGerente);

            TextBlock nif = new TextBlock();
            nif.Text = "NIF: ";
            nif.TextAlignment = TextAlignment.Justify;
            nif.TextTrimming = TextTrimming.CharacterEllipsis;
            viewIDGerente.Child = nif;

            answernif = new TextBox();
            answernif.FontSize = 18;
            answernif.BorderBrush = Brushes.Red;
            answernif.BorderThickness = new Thickness(w * 0.001);
            setSizePositionTextBox(answernif, 0.03, 0.14, 0.18, 0.16);
            AddLojaC.Children.Add(answernif);

            answernif.TextChanged += answernif_TextChanged;

            Button addShop = new Button();
            addShop.IsDefault = true;
            addShop.Width = w * 0.06;
            addShop.Height = h * 0.04;
            Canvas.SetTop(addShop, h * 0.23);
            Canvas.SetLeft(addShop, w * 0.27);

            BitmapImage bitmap = new BitmapImage();
            Image img = new Image();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/WpfApplication3;component/Images/Buttons/Forms/Adicionar.png", UriKind.Relative);
            bitmap.EndInit();
            img.Stretch = Stretch.Fill;
            img.Source = bitmap;
            addShop.Content = img;
            addShop.Background = new ImageBrush(bitmap);

            AddLojaC.Children.Add(addShop);
            addShop.Click += addShopCLICK;

            setScroller("");

            ScrollerGerentes.Height = h * 0.33;
            ScrollerGerentes.Width = w * 0.337;
            Canvas.SetTop(ScrollerGerentes, h * 0.51);
            Canvas.SetLeft(ScrollerGerentes, w * 0.435);
        }

        public void initializeUserData()
        {
            lojaData.Text = MainWindow.nomeLoja;
            lojaData.Foreground = Brushes.Azure;
            funcData.Text = "Funcionário: " + MainWindow.nomeFunc;
            funcData.Foreground = Brushes.Azure;


            lojaView.MinWidth = w * 0.06;
            lojaView.Height = h * 0.03;
            funcView.MinWidth = w * 0.06;
            funcView.Height = h * 0.03;
            Canvas.SetTop(lojaView, h * 0.128);
            Canvas.SetTop(funcView, h * 0.128);
            Canvas.SetLeft(lojaView, w * 0.4);
            Canvas.SetLeft(funcView, w * 0.5);
        }


        public void setSizePositionTextBox(TextBox element, double height, double width, double top, double left)
        {
            element.Height = h * height;
            element.Width = w * width;
            Canvas.SetTop(element, h * top);
            Canvas.SetLeft(element, w * left);
        }

        public void setSizePositionViewBox(Viewbox element, double height, double width, double top, double left)
        {
            element.Height = h * height;
            element.Width = w * width;
            Canvas.SetTop(element, h * top);
            Canvas.SetLeft(element, w * left);
        }

        public void initializeLeftAndTopBar()
        {
            MainWindow.window.myWindow.initializeLeftBarButton(sale, "SaleButton", 0.08, 0.15, 0.22, 0.112);
            MainWindow.window.myWindow.initializeLeftBarButton(stocks, "AddStockButton", 0.08, 0.15, 0.42, 0.112);
            MainWindow.window.myWindow.initializeLeftBarButton(dados, "StatisticsButton", 0.08, 0.15, 0.62, 0.112);

            MainWindow.window.myWindow.initializeTopBar(logOut, "logOut", 0.035, 0.07, 0.1, 0.85);
            MainWindow.window.myWindow.initializeTopBar(settings, "settings", 0.035, 0.075, 0.1, 0.79);

            BlueBarCanvas1.Width = w * 0.14;
            BlueBarCanvas1.Height = h * 0.6;
            Canvas.SetTop(BlueBarCanvas1, h * 0.22);
            Canvas.SetLeft(BlueBarCanvas1, w * 0.21);

            initializeBlueBar(BlueBarCanvas1);

            addFuncionario.IsChecked = true;
        }

        private void initializeBlueBar(Canvas cv)
        {

            //VER NOT WORKING !?!?!?

           /* if (MainWindow.isManager!=true)
            {

            addFuncionario.Visibility = Visibility.Hidden;
            listaFuncionario.Visibility = Visibility.Hidden;
            addLoja.Visibility = Visibility.Hidden;
            listaLoja.Visibility = Visibility.Hidden;
            }*/

            double padding = cv.Height * 0.1;
            double lastheight = 0;
            foreach (ToggleButton b in cv.Children)
            {
                b.Height = cv.Height * 0.05;
                b.Width = cv.Width;
                Canvas.SetTop(b, lastheight);
                lastheight = lastheight + padding;
            }
        }


        public void reset()
        {
            try
            {
                answerNomePessoa.Text = "";
                answerNomePessoa.BorderBrush = Brushes.Red;
                answerBIPessoa.Text = "";
                answerBIPessoa.BorderBrush = Brushes.Red;
                answerNIFPessoa.Text = "";
                answerNIFPessoa.BorderBrush = Brushes.Red;
                answerDiaNascimento.Text = "";
                answerDiaNascimento.BorderBrush = Brushes.Red;
                answerMesNascimento.Text = "";
                answerMesNascimento.BorderBrush = Brushes.Red;
                answerAnoNascimento.Text = "";
                answerAnoNascimento.BorderBrush = Brushes.Red;
                answerMorada.Text = "";
                answerMorada.BorderBrush = Brushes.Red;
                answerContacto.Text = "";
                answerContacto.BorderBrush = Brushes.Red;
                answerMail.Text = "";
                answerMail.BorderBrush = Brushes.Red;
                answerCargoPessoa.Text = "";
                answerCargoPessoa.BorderBrush = Brushes.Red;
                answerSalario.Text = "";
                answerSalario.BorderBrush = Brushes.Red;
                answerNIB.Text = "";
                answerNIB.BorderBrush = Brushes.Red;

                ChangeInfo.Visibility = Visibility.Hidden;
                answer1Update.Text = "";
                answer2Update.Text = "";
                answer2Update.BorderBrush = Brushes.Red;
                answer3Update.Text = "";
                answer3Update.BorderBrush = Brushes.Red;
                answer4Update.Text = "";
                answer4Update.BorderBrush = Brushes.Red;

                answer1Update.IsEnabled = false;
                answer2Update.IsEnabled = false;
                answer3Update.IsEnabled = false;
                answer4Update.IsEnabled = false;

                updatePessoa.Visibility = Visibility.Hidden;
                updatePessoa.IsEnabled = false;

                editPessoa.Visibility = Visibility.Visible;
                editPessoa.IsEnabled = true;

                answernif.Text = "";
                answerPassword.Text = "";
                answerNomeLoja.Text = "";
                answerContactoLoja.Text = "";
                answerMoradaLoja.Text = "";

            }
            catch
            {
            }
        }


        private void addShopCLICK(object sender, RoutedEventArgs e)
        {
            if (answerNomeLoja.Text != "" && answerContactoLoja.Text != "" && answerMoradaLoja.Text != "" &&
                answernif.Text != "")
            {
                
                if (validarString(answerNomeLoja, 30, "Nome Loja") && validarChar(answerContactoLoja, 9, "Contacto") && validarString(answerMoradaLoja, 30, "Morada"))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Games.InsertLoja", Connection.Conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
                        cmd.Parameters["@nome"].Value = answerNomeLoja.Text;

                        cmd.Parameters.Add(new SqlParameter("@contacto", SqlDbType.Char));
                        cmd.Parameters["@contacto"].Value = answerContactoLoja.Text;

                        cmd.Parameters.Add(new SqlParameter("@morada", SqlDbType.VarChar));
                        cmd.Parameters["@morada"].Value = answerMoradaLoja.Text;

                        cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Char));
                        cmd.Parameters["@nif"].Value = answernif.Text;

                        Connection.Conn.Open();
                        cmd.ExecuteNonQuery();
                        Connection.Conn.Close();
                        
                        MessageBox.Show("Loja adicionada com sucesso.");
                        setScroller("");
                    }
                    catch
                    {
                        Connection.Conn.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Tem de preencher todos os campos");
            }
            reset();
        }

        private void updatePessoaCLICK(object sender, RoutedEventArgs e)
        {
            if (answer2Update.Text != "" && answer3Update.Text != "" && answer4Update.Text != "")
            {
                if (activeButton.Equals(listaAderente) || activeButton.Equals(listaLoja))
                {
                    if (validarChar(answer2Update, 9, "Contacto") && validarString(answer3Update, 30, "Morada") && validarString(answer4Update, 30, "Email"))
                    {
                        try
                        {
                            SqlCommand cmd;

                            if (activeButton.Equals(listaAderente))
                            {
                                cmd = new SqlCommand("Games.UpdateCustomer", Connection.Conn);
                            }
                            else
                            {
                                cmd = new SqlCommand("Games.UpdateShop", Connection.Conn);
                            }
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                            cmd.Parameters["@id"].Value = SelectedID;

                            cmd.Parameters.Add(new SqlParameter("@contacto", SqlDbType.Char));
                            cmd.Parameters["@contacto"].Value = answer2Update.Text;

                            cmd.Parameters.Add(new SqlParameter("@morada", SqlDbType.VarChar));
                            cmd.Parameters["@morada"].Value = answer3Update.Text;

                            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.Char));
                            cmd.Parameters["@email"].Value = answer4Update.Text;

                            Connection.Conn.Open();
                            cmd.ExecuteNonQuery();
                            Connection.Conn.Close();

                            if (activeButton.Equals(listaAderente))
                            {
                                initializePessoasGrid("Aderente");

                                editPessoa.Visibility = Visibility.Visible;
                                editPessoa.IsEnabled = true;

                                updatePessoa.Visibility = Visibility.Hidden;
                                updatePessoa.IsEnabled = false;

                                answer1Update.IsEnabled = false;
                                answer2Update.IsEnabled = false;
                                answer3Update.IsEnabled = false;
                                answer4Update.IsEnabled = false;
                                MessageBox.Show("Aderente actualizado com sucesso.");

                                scrollSet("Aderente", Visibility.Visible, true);
                            }
                            else
                            {
                                initializePessoasGrid("Loja");

                                editPessoa.Visibility = Visibility.Visible;
                                editPessoa.IsEnabled = true;

                                updatePessoa.Visibility = Visibility.Hidden;
                                updatePessoa.IsEnabled = false;

                                answer1Update.IsEnabled = false;
                                answer2Update.IsEnabled = false;
                                answer3Update.IsEnabled = false;
                                answer4Update.IsEnabled = false;
                                MessageBox.Show("Loja actualizado com sucesso.");
                            }
                        }
                        catch
                        {
                            Connection.Conn.Close();
                        }
                    }
                }
                else if (activeButton.Equals(listaFuncionario))
                {
                    if (validarChar(answer2Update, 9, "Contacto") && validarString(answer3Update, 20, "Cargo") && validarMegaChar(answer4Update, 21, "NIB"))
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("Games.UpdateEmployee", Connection.Conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                            cmd.Parameters["@id"].Value = SelectedID;

                            cmd.Parameters.Add(new SqlParameter("@contacto", SqlDbType.Char));
                            cmd.Parameters["@contacto"].Value = answer2Update.Text;

                            cmd.Parameters.Add(new SqlParameter("@cargo", SqlDbType.VarChar));
                            cmd.Parameters["@cargo"].Value = answer3Update.Text;

                            cmd.Parameters.Add(new SqlParameter("@nib", SqlDbType.Char));
                            cmd.Parameters["@nib"].Value = answer4Update.Text;

                            Connection.Conn.Open();
                            cmd.ExecuteNonQuery();
                            Connection.Conn.Close();

                            initializePessoasGrid("Funcionario");

                            editPessoa.Visibility = Visibility.Visible;
                            editPessoa.IsEnabled = true;

                            updatePessoa.Visibility = Visibility.Hidden;
                            updatePessoa.IsEnabled = false;

                            answer1Update.IsEnabled = false;
                            answer2Update.IsEnabled = false;
                            answer3Update.IsEnabled = false;
                            answer4Update.IsEnabled = false;

                            MessageBox.Show("Funcionário actualizado com sucesso.");
                            reset();
                        }
                        catch
                        {
                            Connection.Conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Tem de preencher todos os campos!");
            }
        }

        private void removePessoaCLICK(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd;
            DataRowView dataRow = (DataRowView)PessoasGrid.SelectedItem;

            try
            {
                if (activeButton.Equals(listaAderente))
                {
                    cmd = new SqlCommand("Games.RemoveCustomer", Connection.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@bi", SqlDbType.Char));
                    cmd.Parameters["@bi"].Value = dataRow.Row.ItemArray[2].ToString();

                    Connection.Conn.Open();
                    cmd.ExecuteNonQuery();

                    scrollSet("Aderente", Visibility.Visible, true);
                    MessageBox.Show("Aderente Removido com sucesso!");
                    scrollSet("Aderente", Visibility.Visible, true);
                    scrollSet("Aderente", Visibility.Visible, true);
                }
                else if (activeButton.Equals(listaFuncionario))
                {
                    cmd = new SqlCommand("Games.RemovePerson", Connection.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@bi", SqlDbType.Char));
                    cmd.Parameters["@bi"].Value = dataRow.Row.ItemArray[3].ToString(); ;

                    cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar));
                    cmd.Parameters["@tipo"].Value = "Funcionario";

                    Connection.Conn.Open();
                    cmd.ExecuteNonQuery();

                    scrollSet("Funcionario", Visibility.Visible, true);
                    MessageBox.Show("Funcionário removido com sucesso!");
                    scrollSet("Funcionario", Visibility.Visible, true);
                    scrollSet("Funcionario", Visibility.Visible, true);
                }
                else if (activeButton.Equals(listaLoja))
                {
                    cmd = new SqlCommand("Games.RemoveShop", Connection.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Char));
                    cmd.Parameters["@id"].Value = (int)dataRow.Row.ItemArray[0];

                    Connection.Conn.Open();
                    cmd.ExecuteNonQuery();

                    initializePessoasGrid("Loja");
                    scrollSet("Loja", Visibility.Visible, true);
                    MessageBox.Show("Loja removida com sucesso!");
                }
                Connection.Conn.Close();
            }
            catch
            {
                Connection.Conn.Close();
            }
        }

        private void editarPessoaCLICK(object sender, RoutedEventArgs e)
        {
            editPessoa.Visibility = Visibility.Hidden;
            editPessoa.IsEnabled = false;

            updatePessoa.Visibility = Visibility.Visible;
            updatePessoa.IsEnabled = true;

            answer2Update.IsEnabled = true;
            answer3Update.IsEnabled = true;
            answer4Update.IsEnabled = true;
        }

        public void buttonHandlers(string s)
        {
            switch (s)
            {
                case "addFuncionario":
                    activeButton = addFuncionario;
                    AddPessoa.Visibility = Visibility.Visible;
                    AddFuncionario.Visibility = Visibility.Hidden;
                    AddLojaC.Visibility = Visibility.Hidden;
                    Listar.Visibility = Visibility.Hidden;
                    ChangeInfo.Visibility = Visibility.Hidden;
                    ScrollerGerentes.Visibility = Visibility.Hidden;
                    scrollSet("", Visibility.Hidden, false);
                    break;
                case "addAderente":
                    activeButton = addAderente;
                    AddPessoa.Visibility = Visibility.Visible;
                    AddFuncionario.Visibility = Visibility.Hidden;
                    AddLojaC.Visibility = Visibility.Hidden;
                    Listar.Visibility = Visibility.Hidden;
                    ChangeInfo.Visibility = Visibility.Hidden;
                    ScrollerGerentes.Visibility = Visibility.Hidden;
                    scrollSet("", Visibility.Hidden, false);
                    break;
                case "listaFuncionario":
                    activeButton = listaFuncionario;
                    AddPessoa.Visibility = Visibility.Hidden;
                    AddFuncionario.Visibility = Visibility.Hidden;
                    AddLojaC.Visibility = Visibility.Hidden;
                    Listar.Visibility = Visibility.Visible;
                    ChangeInfo.Visibility = Visibility.Hidden;
                    scrollSet("Funcionario", Visibility.Visible, true);
                    ScrollerGerentes.Visibility = Visibility.Hidden;
                    break;
                case "listaAderente":
                    activeButton = listaAderente;
                    AddPessoa.Visibility = Visibility.Hidden;
                    AddFuncionario.Visibility = Visibility.Hidden;
                    AddLojaC.Visibility = Visibility.Hidden;
                    Listar.Visibility = Visibility.Visible;
                    ChangeInfo.Visibility = Visibility.Hidden;
                    scrollSet("Aderente", Visibility.Visible, true);
                    ScrollerGerentes.Visibility = Visibility.Hidden;
                    break;
                case "addLoja":
                    activeButton = addLoja;
                    AddPessoa.Visibility = Visibility.Hidden;
                    AddFuncionario.Visibility = Visibility.Hidden;
                    AddLojaC.Visibility = Visibility.Visible;
                    Listar.Visibility = Visibility.Hidden;
                    ChangeInfo.Visibility = Visibility.Hidden;
                    scrollSet("", Visibility.Hidden, false);
                    setScroller("");
                    ScrollerGerentes.Visibility = Visibility.Visible;
                    break;
                case "listaLoja":
                    activeButton = listaLoja;
                    AddPessoa.Visibility = Visibility.Hidden;
                    AddFuncionario.Visibility = Visibility.Hidden;
                    AddLojaC.Visibility = Visibility.Hidden;
                    Listar.Visibility = Visibility.Visible;
                    ChangeInfo.Visibility = Visibility.Hidden;
                    scrollSet("Loja", Visibility.Visible, true);
                    ScrollerGerentes.Visibility = Visibility.Hidden;
                    break;
                default:
                    MainWindow.window.myClick.buttonOnClickLeftBar(s);
                    break;
            }
            reset();

            foreach (ToggleButton f in BlueBarCanvas1.Children)
            {
                if (f.Equals(activeButton))
                {
                    f.IsChecked = true;
                }
                else
                {
                    f.IsChecked = false;
                }
            }
        }

        private void FilterActivated(object sender, RoutedEventArgs e)
        {
            var b = (ToggleButton)e.OriginalSource;
            buttonHandlers(b.Name);
        }


        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            var b = (Button)e.OriginalSource;
            MainWindow.window.myClick.buttonOnClickLeftBar(b.Name);

            addFuncionario.IsChecked = true;
            reset();
        }

        bool validarInt(TextBox t, string erro)
        {
            bool b = true;
            if (!Regex.IsMatch(t.Text, @"^\d+$"))
            {
                t.BorderBrush = Brushes.Red;
                MessageBox.Show(erro + " Inválido.");
                b = false;
            }
            else if ((!Regex.IsMatch(t.Text, @"^\d+$")) ||
                     ((Regex.IsMatch(t.Text, @"^\d+$")) &&
                      Convert.ToInt32(t.Text) == 0))
            {
                t.BorderBrush = Brushes.Red;
                MessageBox.Show(erro + " Inválido.");
                b = false;
            }
            return b;
        }

        bool validarString(TextBox t, int max, string erro)
        {
            if (t.Text == "" || t.Text.Length > max)
            {
                t.BorderBrush = Brushes.Red;
                MessageBox.Show(erro + " Inválido.");
                return false;
            }
            return true;
        }

        private bool validarData(TextBox answerDia, TextBox answerMes, TextBox answerAno)
        {
            try
            {
                if (answerDia.Text == "" || answerDia.Text.Length > 2 || Convert.ToInt32(answerDia.Text) > 31 || Convert.ToInt32(answerDia.Text) <= 0)
                {
                    answerDia.BorderBrush = Brushes.Red;
                    MessageBox.Show("Dia Inválido.");
                    return false;
                }
                if (answerMes.Text == "" || answerMes.Text.Length > 2 || Convert.ToInt32(answerMes.Text) > 12 || Convert.ToInt32(answerMes.Text) <= 0)
                {
                    answerMes.BorderBrush = Brushes.Red;
                    MessageBox.Show("Mês Inválido.");
                    return false;
                }
                if (answerAno.Text == "" || answerAno.Text.Length > 4 || Convert.ToInt32(answerAno.Text) <= 0)
                {
                    answerAno.BorderBrush = Brushes.Red;
                    MessageBox.Show("Ano Inválido.");
                    return false;
                }
            }
            catch
            {

            }
            return true;
        }

        private bool validarChar(TextBox t, int tamanho, string erro)
        {
            if (t.Text.Length != tamanho)
            {
                t.BorderBrush = Brushes.Red;
                MessageBox.Show(erro + " Inválido.");
                return false;
            }
            return validarInt(t, erro);
        }

        private bool validarMegaChar(TextBox t, int tamanho, string erro)
        {
            if (t.Text.Length != tamanho)
            {
                t.BorderBrush = Brushes.Red;
                MessageBox.Show(erro + " Inválido.");
                return false;
            }
            if (!Regex.IsMatch(t.Text, @"^\d+$"))
            {
                t.BorderBrush = Brushes.Red;
                MessageBox.Show(erro + " Inválido.");
                return false;
            }
            return true;
        }

        private bool validarPassword(TextBox t, string erro)
        {
            if (t.Text == "" || t.Text.Length > 15 || answerPassword.Text.Length <= 5)
            {
                t.BorderBrush = Brushes.Red;
                MessageBox.Show(erro + " Inválida. (Entre 6 e 15 caracteres)");
                return false;
            }
            return true;
        }

        private void addPessoaCLICK(object sender, RoutedEventArgs e)
        {
            if (answerNomePessoa.Text != "" && answerBIPessoa.Text != "" && answerNIFPessoa.Text != ""
                    && answerDiaNascimento.Text != "" && answerMesNascimento.Text != "" && answerAnoNascimento.Text != ""
                    && answerMorada.Text != "" && answerContacto.Text != "" && answerMail.Text != "" && answerGenero.Text!= "")
            {

                if (validarString(answerNomePessoa, 49, "Nome") && validarChar(answerBIPessoa, 9, "BI") && validarChar(answerNIFPessoa, 9, "NIF") &&
                    validarData(answerDiaNascimento, answerMesNascimento, answerAnoNascimento) &&
                    validarString(answerMorada, 29, "Morada") && validarChar(answerContacto, 9, "Contacto") && validarString(answerMail, 30, "Email"))
                {
                    if (activeButton.Equals(addFuncionario))
                    {
                        AddFuncionario.Visibility = Visibility.Visible;
                        AddPessoa.Visibility = Visibility.Hidden;
                    }
                    else if (activeButton.Equals(addAderente))
                    {
                        try
                        {


                            SqlCommand cmd = new SqlCommand("Games.AddCustomer", Connection.Conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            adicionarAtributosPessoa(cmd);
                            
                            Connection.Conn.Open();
                            cmd.ExecuteNonQuery();
                            Connection.Conn.Close();

                            MessageBox.Show("Aderente adicionado com sucesso");
                        }
                        catch
                        {
                            MessageBox.Show("Erro na Rede");
                            Connection.Conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Tem de preencher todos os campos.");
            }
        }

        private void adicionarAtributosPessoa(SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@bi", SqlDbType.Char));
            cmd.Parameters["@bi"].Value = answerBIPessoa.Text;

            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar));
            cmd.Parameters["@name"].Value = answerNomePessoa.Text;

            cmd.Parameters.Add(new SqlParameter("@nif", SqlDbType.Char));
            cmd.Parameters["@nif"].Value = answerNIFPessoa.Text;

            cmd.Parameters.Add(new SqlParameter("@data_nasc", SqlDbType.Date));
            string date = answerMesNascimento.Text + "-" + answerDiaNascimento.Text + "-" + answerAnoNascimento.Text;
            DateTime dataNascimento = DateTime.ParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters["@data_nasc"].Value = dataNascimento;

            cmd.Parameters.Add(new SqlParameter("@genero", SqlDbType.Char));
            cmd.Parameters["@genero"].Value = answerGenero.Text;

            cmd.Parameters.Add(new SqlParameter("@morada", SqlDbType.VarChar));
            cmd.Parameters["@morada"].Value = answerMorada.Text;

            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
            cmd.Parameters["@email"].Value = answerMail.Text;

            cmd.Parameters.Add(new SqlParameter("@contacto", SqlDbType.Char));
            cmd.Parameters["@contacto"].Value = answerContacto.Text;
        }

        private void addFuncionarioCLICK(object sender, RoutedEventArgs e)
        {
            if (answerCargoPessoa.Text != "" && answerSalario.Text != "" && answerNIB.Text != "" && answerPassword.Text != "")
            {
                if (validarString(answerCargoPessoa, 20, "Cargo") && validarInt(answerSalario, "Salário") &&
                    validarMegaChar(answerNIB, 21, "NIB") && validarPassword(answerPassword, "Password"))
                {
                    try
                    {

                        SqlCommand cmd = new SqlCommand("Games.AddEmployee", Connection.Conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        adicionarAtributosPessoa(cmd);

                        cmd.Parameters.Add(new SqlParameter("@cargo", SqlDbType.VarChar));
                        cmd.Parameters["@cargo"].Value = answerCargoPessoa.Text;

                        cmd.Parameters.Add(new SqlParameter("@salario", SqlDbType.Decimal));
                        cmd.Parameters["@salario"].Value = Int32.Parse(answerSalario.Text);

                        cmd.Parameters.Add(new SqlParameter("@nib", SqlDbType.Char));
                        cmd.Parameters["@nib"].Value = answerNIB.Text;

                        cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar));
                        cmd.Parameters["@pass"].Value = answerPassword.Text;

                        cmd.Parameters.Add(new SqlParameter("@id_loja", SqlDbType.Int));
                        cmd.Parameters["@id_loja"].Value = MainWindow.idLoja;


                        Connection.Conn.Open();
                        cmd.ExecuteNonQuery();
                        Connection.Conn.Close();

                        MessageBox.Show("Funcionário adicionado com sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Connection.Conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Tem de preencher todos os campos.");
            }
        }

        void validateInt(TextBox t)
        {
            if (!Regex.IsMatch(t.Text, @"^\d+$"))
            {
                t.BorderBrush = Brushes.Red;
            }
            else
            {
                t.BorderBrush = Brushes.Green;
            }
        }

        void validateString(TextBox t, int limite)
        {
            if (t.Text == "" || t.Text.Length > limite)
            {
                t.BorderBrush = Brushes.Red;
            }
            else
            {
                t.BorderBrush = Brushes.Green;
            }
        }

        void validateChar(TextBox t, int tamanho)
        {
            if (t.Text.Length != tamanho)
            {
                t.BorderBrush = Brushes.Red;
            }
            else
            {
                validateInt(t);
            }
        }

        private void answernif_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(answernif.Text, @"^\d+$"))
            {
                answernif.BorderBrush = Brushes.Red;
            }
            else
            {
                try
                {
                    Boolean result = true;
                    if (result == true)
                    {
                        answernif.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        answernif.BorderBrush = Brushes.Red;
                    }
                }
                catch
                {
                }
            }
        }

        void answerMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateString(answerMail, 29);
        }

        void answerContacto_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateChar(answerContacto, 9);
        }

        void answerMorada_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateString(answerMorada, 30);
        }

        private void answerAnoNascimento_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (answerAnoNascimento.Text == "" || answerAnoNascimento.Text.Length > 4 || Convert.ToInt32(answerAnoNascimento.Text) <= 0)
                {
                    answerAnoNascimento.BorderBrush = Brushes.Red;
                }
                else
                {
                    validateChar(answerAnoNascimento, 4);
                }
            }
            catch
            {
                answerAnoNascimento.BorderBrush = Brushes.Red;
            }
        }

        private void answerMesNascimento_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (answerMesNascimento.Text == "" || answerMesNascimento.Text.Length > 2 || Convert.ToInt32(answerMesNascimento.Text) <= 0 || Convert.ToInt32(answerMesNascimento.Text) > 12)
                {
                    answerMesNascimento.BorderBrush = Brushes.Red;
                }
                else
                {
                    validateChar(answerMesNascimento, 2);
                }
            }
            catch
            {
                answerMesNascimento.BorderBrush = Brushes.Red;
            }
        }

        void answerDiaNascimento_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (answerDiaNascimento.Text == "" || answerDiaNascimento.Text.Length > 2 || Convert.ToInt32(answerDiaNascimento.Text) <= 0 || Convert.ToInt32(answerDiaNascimento.Text) > 31)
                {
                    answerDiaNascimento.BorderBrush = Brushes.Red;
                }
                else
                {
                    validateChar(answerDiaNascimento, 2);
                }
            }
            catch
            {
                answerDiaNascimento.BorderBrush = Brushes.Red;
            }
        }

        void answerNIFPessoa_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateChar(answerNIFPessoa, 9);
        }

        void answerBIPessoa_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateChar(answerBIPessoa, 9);
        }

        void answerNomePessoa_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateString(answerNomePessoa, 29);
        }
        void answerGenero_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateString(answerGenero, 1);
        }
        void answerNIB_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateChar(answerNIB, 21);
        }

        private void answerPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (answerPassword.Text == "" || answerPassword.Text.Length > 15 || answerPassword.Text.Length <= 5)
            {
                answerPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                answerPassword.BorderBrush = Brushes.Green;
            }
        }

        void answerSalario_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateInt(answerSalario);
        }

        void answerCargoPessoa_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateString(answerCargoPessoa, 19);
        }


        private void answerMoradaLoja_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateString(answerMoradaLoja, 29);
        }

        private void answerContactoLoja_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateInt(answerContactoLoja);
        }

        void answerNomeLoja_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateString(answerNomeLoja, 29);
        }

        private void answer4Update_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (activeButton.Equals(listaFuncionario))
            {
                validateChar(answer4Update, 21);
            }
            else if (activeButton.Equals(listaAderente) || activeButton.Equals(listaLoja))
            {
                validateString(answer4Update, 29);
            }
        }

        private void answer3Update_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (activeButton.Equals(listaFuncionario))
            {
                validateString(answer3Update, 19);
            }
            else if (activeButton.Equals(listaAderente) || activeButton.Equals(listaLoja))
            {
                validateString(answer3Update, 30);
            }
        }

        private void answer2Update_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateChar(answer2Update, 9);
        }

        private void scrollSet(string name, Visibility visibility, bool enable)
        {
            initializePessoasGrid(name);
            ScrollerPessoas.Visibility = visibility;
            ScrollerPessoas.IsEnabled = enable;
        }

        private void initializePessoasGrid(string name)
        {
            try
            {
                Connection.Conn.Open();
                string command;
                if (name == "Aderente" || name == "Funcionario")
                {
                    command = "exec Games.ListEmpCos '" + name + "';";
                }
                else
                {
                    command = "exec Games.ListShops;";
                }

                SqlCommand cmd = new SqlCommand(command);
                SqlDataAdapter sda = new SqlDataAdapter(command, Connection.Conn);
                DataTable dt = new DataTable(name);
                sda.Fill(dt);
                PessoasGrid.ItemsSource = dt.DefaultView;
                PessoasGrid.FontSize = 20;
                PessoasGrid.IsReadOnly = true;
                PessoasGrid.SelectedCellsChanged += PessoasGrid_SelectedCellsChanged;
                Connection.Conn.Close();
               

            }
            catch
            {
                Connection.Conn.Close();
            }
        }

        private void PessoasGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ChangeInfo.Visibility = Visibility.Visible;

            editPessoa.Visibility = Visibility.Visible;
            editPessoa.IsEnabled = true;

            updatePessoa.Visibility = Visibility.Hidden;
            updatePessoa.IsEnabled = false;

            answer1Update.IsEnabled = false;
            answer2Update.IsEnabled = false;
            answer3Update.IsEnabled = false;
            answer4Update.IsEnabled = false;

            if (activeButton.Equals(listaAderente))
            {
                DataRowView dataRow = (DataRowView)PessoasGrid.SelectedItem;
                int cellValue = (int)dataRow.Row.ItemArray[0];
                initializePessoasGrid(cellValue, "Aderentes");
                setSizePositionViewBox(view3, 0.03, 0.1, 0.13, 0.011);
                ans3.Text = "Morada:";
                setSizePositionViewBox(view4, 0.03, 0.1, 0.18, 0.004);
                ans4.Text = "Email:";
            }
            else if (activeButton.Equals(listaFuncionario))
            {
                DataRowView dataRow = (DataRowView)PessoasGrid.SelectedItem;
                int cellValue = (int)dataRow.Row.ItemArray[0];
                initializePessoasGrid(cellValue, "Funcionarios");
                setSizePositionViewBox(view3, 0.03, 0.1, 0.13, 0.006);
                ans3.Text = "Cargo:";
                setSizePositionViewBox(view4, 0.03, 0.1, 0.18, 0.001);
                ans4.Text = "NIB:";
            }
            else if (activeButton.Equals(listaLoja))
            {
                DataRowView dataRow = (DataRowView)PessoasGrid.SelectedItem;
                int cellValue = (int)dataRow.Row.ItemArray[0];
                initializePessoasGrid(cellValue, "Lojas");
                setSizePositionViewBox(view3, 0.03, 0.1, 0.13, 0.011);
                ans3.Text = "Morada:";
                setSizePositionViewBox(view4, 0.03, 0.1, 0.18, 0.004);
                ans4.Text = "Email:";
            }
            else if (activeButton.Equals(addLoja))
            {
                DataRowView dataRow = (DataRowView)PessoasGrid.SelectedItem;
                string cellValue = dataRow.Row.ItemArray[0].ToString();
            }
        }

        private void setScroller(string p)
        {
            try
            {
                Connection.Conn.Open();
                string command;
                command = "exec Games.ListShops;";

                SqlCommand cmd = new SqlCommand(command);
                SqlDataAdapter sda = new SqlDataAdapter(command, Connection.Conn);
                DataTable dt = new DataTable("Funcionários Disponiveis");
                sda.Fill(dt);
                GerentesGrid.ItemsSource = dt.DefaultView;
                Connection.Conn.Close();
                
            }
            catch
            {
                Connection.Conn.Close();
            }
        }


        private void initializePessoasGrid(int code, string nome)
        {
            SelectedID = code;
            try
            {
                SqlCommand cmd;

                if (nome == "Funcionarios")
                {
                    
                    cmd = new SqlCommand("Games.GetEmployeeInfo", Connection.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", code);

                    var returnName = cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    returnName.Size = 30;
                    returnName.Direction = ParameterDirection.Output;

                    var returnContacto = cmd.Parameters.Add("@contacto", SqlDbType.Char);
                    returnContacto.Size = 9;
                    returnContacto.Direction = ParameterDirection.Output;

                    var returnCargo = cmd.Parameters.Add("@cargo", SqlDbType.VarChar);
                    returnCargo.Size = 20;
                    returnCargo.Direction = ParameterDirection.Output;

                    var returnNIB = cmd.Parameters.Add("@nib", SqlDbType.Char);
                    returnNIB.Size = 21;
                    returnNIB.Direction = ParameterDirection.Output;

                    Connection.Conn.Open();
                    cmd.ExecuteNonQuery();

                    answer1Update.Text = (string)cmd.Parameters["@nome"].Value;
                    answer2Update.Text = (string)cmd.Parameters["@contacto"].Value;
                    answer3Update.Text = (string)cmd.Parameters["@cargo"].Value;
                    answer4Update.Text = (string)cmd.Parameters["@nib"].Value;
                    

                }
                else if (nome == "Aderentes")
                {
                    cmd = new SqlCommand("Games.GetCustomerInfo", Connection.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", code);

                    var returnName = cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    returnName.Size = 30;
                    returnName.Direction = ParameterDirection.Output;

                    var returnContacto = cmd.Parameters.Add("@contacto", SqlDbType.Char);
                    returnContacto.Size = 9;
                    returnContacto.Direction = ParameterDirection.Output;

                    var returnMorada = cmd.Parameters.Add("@morada", SqlDbType.VarChar);
                    returnMorada.Size = 30;
                    returnMorada.Direction = ParameterDirection.Output;

                    var returnEmail = cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    returnEmail.Size = 30;
                    returnEmail.Direction = ParameterDirection.Output;

                    Connection.Conn.Open();
                    cmd.ExecuteNonQuery();

                    answer1Update.Text = (string)cmd.Parameters["@nome"].Value;
                    answer2Update.Text = (string)cmd.Parameters["@contacto"].Value;
                    answer3Update.Text = (string)cmd.Parameters["@morada"].Value;
                    answer4Update.Text = (string)cmd.Parameters["@email"].Value;
                }
                else if (nome == "Lojas")
                {
                    cmd = new SqlCommand("Games.GetShopInfo", Connection.Conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", code);

                    var returnName = cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    returnName.Size = 30;
                    returnName.Direction = ParameterDirection.Output;

                    var returnContacto = cmd.Parameters.Add("@contacto", SqlDbType.Char);
                    returnContacto.Size = 9;
                    returnContacto.Direction = ParameterDirection.Output;

                    var returnMorada = cmd.Parameters.Add("@morada", SqlDbType.VarChar);
                    returnMorada.Size = 30;
                    returnMorada.Direction = ParameterDirection.Output;

                    var returnEmail = cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    returnEmail.Size = 30;
                    returnEmail.Direction = ParameterDirection.Output;

                    Connection.Conn.Open();
                    cmd.ExecuteNonQuery();

                    answer1Update.Text = (string)cmd.Parameters["@nome"].Value;
                    answer2Update.Text = (string)cmd.Parameters["@contacto"].Value;
                    answer3Update.Text = (string)cmd.Parameters["@morada"].Value;
                    answer4Update.Text = (string)cmd.Parameters["@email"].Value;
                }
                Connection.Conn.Close();

            }
            catch
            {
               Connection.Conn.Close();
            }
        }

        
    }
}
