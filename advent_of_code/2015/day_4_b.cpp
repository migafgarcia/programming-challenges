#include <iostream>
#include <openssl/md5.h>
#include <vector>

using namespace std;

int main() {

    string input = "bgvyzdsv";

    MD5_CTX context;
    unsigned char digest[16];

    for(int i = 0; ; i++) {
        string s = input + to_string(i);
        MD5_Init(&context);
        MD5_Update(&context, s.c_str(), s.size());
        MD5_Final(digest, &context);
        if(digest[0] == 0 && digest[1] == 0 && digest[2] == 0) {
            cout << to_string(i) << endl;
            break;
        }
    }

    return 0;
}