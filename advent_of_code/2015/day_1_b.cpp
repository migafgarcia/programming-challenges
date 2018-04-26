#include <iostream>

using namespace std;


int main() {
    string input; // input goes here

    int floor = 0;

    for(char& c : input) {
        if(c == '(')
            floor++;
        else
            floor--;

        if(floor == -1) {
            cout << "Position: " << &c - &input[0] + 1;
            break;
        }
    }

    return 0;
}
