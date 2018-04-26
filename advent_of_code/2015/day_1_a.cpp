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
    }

    cout << "Floor: " << floor;

    return 0;
}
