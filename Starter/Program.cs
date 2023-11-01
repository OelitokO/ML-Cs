/* 
Bu C# konsol uygulaması aşağıdaki amaçlar için tasarlanmıştır:
- Öğrenci adlarını ve ödev puanlarını saklamak için dizileri kullanın.
- Öğrenci adları arasında bir dış program döngüsü olarak yineleme yapmak için bir 'foreach' ifadesi kullanın.
- Geçerli öğrenci adını tanımlamak ve öğrencinin ödev puanlarına erişmek için dış döngü içinde bir "if" ifadesi kullanın.
- Atama puanları dizisini yinelemek ve değerleri toplamak için dış döngü içinde bir "foreach" ifadesi kullanın.
- Her öğrencinin ortalama sınav puanını hesaplamak için dış döngü içindeki bir algoritmayı kullanın.
- Ortalama sınav puanını değerlendirmek ve otomatik olarak bir harf notu atamak için dış döngü içinde "if-elseif-else" yapısını kullanın.
- Öğrencinin final puanını ve harf notunu hesaplarken ekstra kredi puanlarını aşağıdaki şekilde entegre edin:
     - öğrencinin puan dizisindeki öğe sayısına göre ekstra kredi atamalarını algılar.
     - sınav puanlarının toplamına ekstra kredi puanları eklemeden önce ekstra kredi ödevlerinin değerlerini 10'a böler.
- öğrenci notlarını raporlamak için aşağıdaki rapor formatını kullanın:
    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
int examAssignments = 5;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

int[] studentScores = new int[10];

string currentStudentLetterGrade = "";

// puanlar/notlar için başlık satırını görüntüleConsole.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall\tGrade\tExtra Credit\n");

/*
Dış foreach döngüsü şu amaçlarla kullanılır:
- öğrenci adlarını yineleyin
- bir öğrencinin notlarını studentScores dizisine atayın
- toplam atama puanları (iç foreach döngüsü)
- sayısal ve harf notunu hesaplayın
- puan raporu bilgilerini yazın
*/
foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
        studentScores = loganScores;

    int sumAssignmentScores = 0;

    decimal currentStudentGrade = 0;

    int gradedAssignments = 0;

    /* 
iç foreach döngüsü atama puanlarını toplar
     Ekstra kredi ödevleri sınav puanının %10'u değerindedir
    */
    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
            sumAssignmentScores += score;

        else
            sumAssignmentScores += score / 10;
    }

    currentStudentGrade = (decimal)(sumAssignmentScores) / examAssignments;

    if (currentStudentGrade >= 97)
        currentStudentLetterGrade = "A+";

    else if (currentStudentGrade >= 93)
        currentStudentLetterGrade = "A";

    else if (currentStudentGrade >= 90)
        currentStudentLetterGrade = "A-";

    else if (currentStudentGrade >= 87)
        currentStudentLetterGrade = "B+";

    else if (currentStudentGrade >= 83)
        currentStudentLetterGrade = "B";

    else if (currentStudentGrade >= 80)
        currentStudentLetterGrade = "B-";

    else if (currentStudentGrade >= 77)
        currentStudentLetterGrade = "C+";

    else if (currentStudentGrade >= 73)
        currentStudentLetterGrade = "C";

    else if (currentStudentGrade >= 70)
        currentStudentLetterGrade = "C-";

    else if (currentStudentGrade >= 67)
        currentStudentLetterGrade = "D+";

    else if (currentStudentGrade >= 63)
        currentStudentLetterGrade = "D";

    else if (currentStudentGrade >= 60)
        currentStudentLetterGrade = "D-";

    else
        currentStudentLetterGrade = "F";

    // Student         Grade
    // Sophia:         92.2    A-
    
    Console.WriteLine($"{currentStudent}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}");
}

//VS Kodunda çalıştırmak için gereklidir (sonuçları görüntülemek için Çıkış pencerelerini açık tutar)
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
