#include <bits/stdc++.h>
#include "info.cpp"
using namespace std;
string int_toString(int i), produceSpace(int num), chararr2string(char arg[]);
void printSourceCode(queue<string> lines);
bool exist_in_array(int num, char* argv[], string tar);

/// int 转 string
string int_toString(int i){
    ostringstream os;
    os << i;
    return os.str();
}
/// 产生指定数量的空格
string produceSpace(int num){
    string s;
    for(int i = 0; i < num; ++ i) s += ' ';
    return s;
}
string chararr2string(char arg[]){
    string rs;
    for(int i = 0; i < strlen(arg); ++ i) rs += arg[i];
    return rs;
}
/// 打印源代码
void printSourceCode(queue<string> lines){
    int size = lines.size();
    printf("%s\n", infos[0].replace(infos[0].find("$data$"), 6, int_toString(size)).c_str());
    printf("%s\n\n", infos[1].c_str());
    for(int i = 0; i < size; ++ i){
        printf("%d%s | %s\n", i + 1, produceSpace(int_toString(size).length() - int_toString(i + 1).length()).c_str(), lines.front().c_str());
        lines.push(lines.front()); lines.pop();
    }
}
/// 遍历参数，返回是否存在
bool exist_in_array(int num, char* argv[], string tar){
    for(int i = 0; i < num; ++ i) if(chararr2string(argv[i]) == tar.c_str()) return true;
    return false;
}