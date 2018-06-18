#include <iostream>
#include <sstream>
#include <regex>


using namespace std;

const int SIZE = 1000;

void update_matrix(cmatch results, bool matrix[SIZE][SIZE], bool value);
void toggle_matrix(cmatch results, bool matrix[SIZE][SIZE]);

int main() {
    const string input = "toggle 461,550 through 564,900\nturn off 370,39 through 425,839\nturn off 464,858 through 833,915\nturn off 812,389 through 865,874\nturn on 599,989 through 806,993\nturn on 376,415 through 768,548\nturn on 606,361 through 892,600\nturn off 448,208 through 645,684\ntoggle 50,472 through 452,788\ntoggle 205,417 through 703,826\ntoggle 533,331 through 906,873\ntoggle 857,493 through 989,970\nturn off 631,950 through 894,975\nturn off 387,19 through 720,700\nturn off 511,843 through 581,945\ntoggle 514,557 through 662,883\nturn off 269,809 through 876,847\nturn off 149,517 through 716,777\nturn off 994,939 through 998,988\ntoggle 467,662 through 555,957\nturn on 952,417 through 954,845\nturn on 565,226 through 944,880\nturn on 214,319 through 805,722\ntoggle 532,276 through 636,847\ntoggle 619,80 through 689,507\nturn on 390,706 through 884,722\ntoggle 17,634 through 537,766\ntoggle 706,440 through 834,441\ntoggle 318,207 through 499,530\ntoggle 698,185 through 830,343\ntoggle 566,679 through 744,716\ntoggle 347,482 through 959,482\ntoggle 39,799 through 981,872\nturn on 583,543 through 846,710\nturn off 367,664 through 595,872\nturn on 805,439 through 964,995\ntoggle 209,584 through 513,802\nturn off 106,497 through 266,770\nturn on 975,2 through 984,623\nturn off 316,684 through 369,876\nturn off 30,309 through 259,554\nturn off 399,680 through 861,942\ntoggle 227,740 through 850,829\nturn on 386,603 through 552,879\nturn off 703,795 through 791,963\nturn off 573,803 through 996,878\nturn off 993,939 through 997,951\nturn on 809,221 through 869,723\nturn off 38,720 through 682,751\nturn off 318,732 through 720,976\ntoggle 88,459 through 392,654\nturn off 865,654 through 911,956\ntoggle 264,284 through 857,956\nturn off 281,776 through 610,797\ntoggle 492,660 through 647,910\nturn off 879,703 through 925,981\nturn off 772,414 through 974,518\nturn on 694,41 through 755,96\nturn on 452,406 through 885,881\nturn off 107,905 through 497,910\nturn off 647,222 through 910,532\nturn on 679,40 through 845,358\nturn off 144,205 through 556,362\nturn on 871,804 through 962,878\nturn on 545,676 through 545,929\nturn off 316,716 through 413,941\ntoggle 488,826 through 755,971\ntoggle 957,832 through 976,992\ntoggle 857,770 through 905,964\ntoggle 319,198 through 787,673\nturn on 832,813 through 863,844\nturn on 818,296 through 818,681\nturn on 71,699 through 91,960\nturn off 838,578 through 967,928\ntoggle 440,856 through 507,942\ntoggle 121,970 through 151,974\ntoggle 391,192 through 659,751\nturn on 78,210 through 681,419\nturn on 324,591 through 593,939\ntoggle 159,366 through 249,760\nturn off 617,167 through 954,601\ntoggle 484,607 through 733,657\nturn on 587,96 through 888,819\nturn off 680,984 through 941,991\nturn on 800,512 through 968,691\nturn off 123,588 through 853,603\nturn on 1,862 through 507,912\nturn on 699,839 through 973,878\nturn off 848,89 through 887,893\ntoggle 344,353 through 462,403\nturn on 780,731 through 841,760\ntoggle 693,973 through 847,984\ntoggle 989,936 through 996,958\ntoggle 168,475 through 206,963\nturn on 742,683 through 769,845\ntoggle 768,116 through 987,396\nturn on 190,364 through 617,526\nturn off 470,266 through 530,839\ntoggle 122,497 through 969,645\nturn off 492,432 through 827,790\nturn on 505,636 through 957,820\nturn on 295,476 through 698,958\ntoggle 63,298 through 202,396\nturn on 157,315 through 412,939\nturn off 69,789 through 134,837\nturn off 678,335 through 896,541\ntoggle 140,516 through 842,668\nturn off 697,585 through 712,668\ntoggle 507,832 through 578,949\nturn on 678,279 through 886,621\ntoggle 449,744 through 826,910\nturn off 835,354 through 921,741\ntoggle 924,878 through 985,952\nturn on 666,503 through 922,905\nturn on 947,453 through 961,587\ntoggle 525,190 through 795,654\nturn off 62,320 through 896,362\nturn on 21,458 through 972,536\nturn on 446,429 through 821,970\ntoggle 376,423 through 805,455\ntoggle 494,896 through 715,937\nturn on 583,270 through 667,482\nturn off 183,468 through 280,548\ntoggle 623,289 through 750,524\nturn on 836,706 through 967,768\nturn on 419,569 through 912,908\nturn on 428,260 through 660,433\nturn off 683,627 through 916,816\nturn on 447,973 through 866,980\nturn on 688,607 through 938,990\nturn on 245,187 through 597,405\nturn off 558,843 through 841,942\nturn off 325,666 through 713,834\ntoggle 672,606 through 814,935\nturn off 161,812 through 490,954\nturn on 950,362 through 985,898\nturn on 143,22 through 205,821\nturn on 89,762 through 607,790\ntoggle 234,245 through 827,303\nturn on 65,599 through 764,997\nturn on 232,466 through 965,695\nturn on 739,122 through 975,590\nturn off 206,112 through 940,558\ntoggle 690,365 through 988,552\nturn on 907,438 through 977,691\nturn off 838,809 through 944,869\nturn on 222,12 through 541,832\ntoggle 337,66 through 669,812\nturn on 732,821 through 897,912\ntoggle 182,862 through 638,996\nturn on 955,808 through 983,847\ntoggle 346,227 through 841,696\nturn on 983,270 through 989,756\nturn off 874,849 through 876,905\nturn off 7,760 through 678,795\ntoggle 973,977 through 995,983\nturn off 911,961 through 914,976\nturn on 913,557 through 952,722\nturn off 607,933 through 939,999\nturn on 226,604 through 517,622\nturn off 3,564 through 344,842\ntoggle 340,578 through 428,610\nturn on 248,916 through 687,925\ntoggle 650,185 through 955,965\ntoggle 831,359 through 933,536\nturn off 544,614 through 896,953\ntoggle 648,939 through 975,997\nturn on 464,269 through 710,521\nturn off 643,149 through 791,320\nturn off 875,549 through 972,643\nturn off 953,969 through 971,972\nturn off 236,474 through 772,591\ntoggle 313,212 through 489,723\ntoggle 896,829 through 897,837\ntoggle 544,449 through 995,905\nturn off 278,645 through 977,876\nturn off 887,947 through 946,977\nturn on 342,861 through 725,935\nturn on 636,316 through 692,513\ntoggle 857,470 through 950,528\nturn off 736,196 through 826,889\nturn on 17,878 through 850,987\nturn on 142,968 through 169,987\nturn on 46,470 through 912,853\nturn on 182,252 through 279,941\ntoggle 261,143 through 969,657\nturn off 69,600 through 518,710\nturn on 372,379 through 779,386\ntoggle 867,391 through 911,601\nturn off 174,287 through 900,536\ntoggle 951,842 through 993,963\nturn off 626,733 through 985,827\ntoggle 622,70 through 666,291\nturn off 980,671 through 985,835\nturn off 477,63 through 910,72\nturn off 779,39 through 940,142\nturn on 986,570 through 997,638\ntoggle 842,805 through 943,985\nturn off 890,886 through 976,927\nturn off 893,172 through 897,619\nturn off 198,780 through 835,826\ntoggle 202,209 through 219,291\nturn off 193,52 through 833,283\ntoggle 414,427 through 987,972\nturn on 375,231 through 668,236\nturn off 646,598 through 869,663\ntoggle 271,462 through 414,650\nturn off 679,121 through 845,467\ntoggle 76,847 through 504,904\nturn off 15,617 through 509,810\ntoggle 248,105 through 312,451\nturn off 126,546 through 922,879\nturn on 531,831 through 903,872\ntoggle 602,431 through 892,792\nturn off 795,223 through 892,623\ntoggle 167,721 through 533,929\ntoggle 813,251 through 998,484\ntoggle 64,640 through 752,942\nturn on 155,955 through 892,985\nturn on 251,329 through 996,497\nturn off 341,716 through 462,994\ntoggle 760,127 through 829,189\nturn on 86,413 through 408,518\ntoggle 340,102 through 918,558\nturn off 441,642 through 751,889\nturn on 785,292 through 845,325\nturn off 123,389 through 725,828\nturn on 905,73 through 983,270\nturn off 807,86 through 879,276\ntoggle 500,866 through 864,916\nturn on 809,366 through 828,534\ntoggle 219,356 through 720,617\nturn off 320,964 through 769,990\nturn off 903,167 through 936,631\ntoggle 300,137 through 333,693\ntoggle 5,675 through 755,848\nturn off 852,235 through 946,783\ntoggle 355,556 through 941,664\nturn on 810,830 through 867,891\nturn off 509,869 through 667,903\ntoggle 769,400 through 873,892\nturn on 553,614 through 810,729\nturn on 179,873 through 589,962\nturn off 466,866 through 768,926\ntoggle 143,943 through 465,984\ntoggle 182,380 through 569,552\nturn off 735,808 through 917,910\nturn on 731,802 through 910,847\nturn off 522,74 through 731,485\nturn on 444,127 through 566,996\nturn off 232,962 through 893,979\nturn off 231,492 through 790,976\nturn on 874,567 through 943,684\ntoggle 911,840 through 990,932\ntoggle 547,895 through 667,935\nturn off 93,294 through 648,636\nturn off 190,902 through 532,970\nturn off 451,530 through 704,613\ntoggle 936,774 through 937,775\nturn off 116,843 through 533,934\nturn on 950,906 through 986,993\nturn on 910,51 through 945,989\nturn on 986,498 through 994,945\nturn off 125,324 through 433,704\nturn off 60,313 through 75,728\nturn on 899,494 through 940,947\ntoggle 832,316 through 971,817\ntoggle 994,983 through 998,984\ntoggle 23,353 through 917,845\ntoggle 174,799 through 658,859\nturn off 490,878 through 534,887\nturn off 623,963 through 917,975\ntoggle 721,333 through 816,975\ntoggle 589,687 through 890,921\nturn on 936,388 through 948,560\nturn off 485,17 through 655,610\nturn on 435,158 through 689,495\nturn on 192,934 through 734,936\nturn off 299,723 through 622,847\ntoggle 484,160 through 812,942\nturn off 245,754 through 818,851\nturn on 298,419 through 824,634\ntoggle 868,687 through 969,760\ntoggle 131,250 through 685,426\nturn off 201,954 through 997,983\nturn on 353,910 through 832,961\nturn off 518,781 through 645,875\nturn off 866,97 through 924,784\ntoggle 836,599 through 857,767\nturn on 80,957 through 776,968\ntoggle 277,130 through 513,244\nturn off 62,266 through 854,434\nturn on 792,764 through 872,842\nturn off 160,949 through 273,989\nturn off 664,203 through 694,754\ntoggle 491,615 through 998,836\nturn off 210,146 through 221,482\nturn off 209,780 through 572,894\nturn on 766,112 through 792,868\nturn on 222,12 through 856,241\n";
    const regex off ("turn off ([0-9]{1,3}),([0-9]{1,3}) through ([0-9]{1,3}),([0-9]{1,3})");
    const regex toggle ("toggle ([0-9]{1,3}),([0-9]{1,3}) through ([0-9]{1,3}),([0-9]{1,3})");
    const regex on ("turn on ([0-9]{1,3}),([0-9]{1,3}) through ([0-9]{1,3}),([0-9]{1,3})");

    cmatch match;

    istringstream stream{input};

    bool matrix[SIZE][SIZE] = {false};

    string line;

    while (getline(stream, line)) {
        if (regex_search(line.c_str(), match, off))
            update_matrix(match, matrix, false);
        if (regex_search(line.c_str(), match, toggle))
            toggle_matrix(match, matrix);
        if (regex_search(line.c_str(), match, on))
            update_matrix(match, matrix, true);
    }

    int c = 0;
    for(int i = 0; i < SIZE; i++)
        for(int j = 0; j < SIZE; j++)
            if(matrix[i][j]) c++;

    cout << c << endl;

}

void update_matrix(cmatch results, bool matrix[SIZE][SIZE], bool value) {

    int a_x = stoi(results[1]);
    int a_y = stoi(results[2]);
    int b_x = stoi(results[3]);
    int b_y = stoi(results[4]);

//    cout << a_x << " " << a_y << " " << b_x << " " << b_y << endl;

    for (int i = a_x; i <= b_x; i++)
        for (int j = a_y; j <= b_y; j++)
            matrix[i][j] = value;

}

void toggle_matrix(cmatch results, bool matrix[SIZE][SIZE]) {

    int a_x = stoi(results[1]);
    int a_y = stoi(results[2]);
    int b_x = stoi(results[3]);
    int b_y = stoi(results[4]);

//    cout << a_x << " " << a_y << " " << b_x << " " << b_y << endl;

    for (int i = a_x; i <= b_x; i++)
        for (int j = a_y; j <= b_y; j++)
            matrix[i][j] = !matrix[i][j];

}