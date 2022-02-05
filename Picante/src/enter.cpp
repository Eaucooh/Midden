#include <bits/stdc++.h>
#include "console.cpp"
#include "analyser.cpp"
using namespace std;

// 进入命令行解释环境
void enterCommandLineEnviro(){

}
// 主函数
int main(int argc, char* argv[]){
    if(argc == 1) enterCommandLineEnviro();
    else{
        queue<string> lines;
        ifstream infile;
        infile.open(argv[1], ios::in);
        if(!infile.is_open()){
            printf("\nRead File Err : %s : Open Failed!\n", argv[1]);
            return 0;
        }
        string tmp;
        while(getline(infile, tmp)) lines.push(tmp);
        if(exist_in_array(argc, argv, "--view")) printSourceCode(lines);
        if(exist_in_array(argc, argv, "--vars")) printAllVars();
        // int result = analyse(lines, 1);
        int size = lines.size();
        for(int i = 0; i < size; ++ i){
            analyse(lines.front());
            lines.push(lines.front());
            lines.pop();
        }
        // printf("%s\n", errs[result].c_str());
    }
    return 0;
}