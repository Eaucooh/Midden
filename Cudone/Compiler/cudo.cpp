#include <bits/stdc++.h>
#include <sys/stat.h>
#include <unistd.h>
#include <sstream>
#include <fstream>
#include <locale>
#define cmdNUM 4
#define rnrn spt(100);
using namespace std;
void spt(int length){
    while(length --) { printf("-%s", length == 0 ? "\n" : ""); }
}

bool IsPathExist(string path) {
    if (access(path.c_str(), 0) == F_OK) {
        return true;
    }
    return false;
}

bool IsFile(string path) {
    if (!IsPathExist(path)) {
        return false;
    }
    struct stat buffer;
    return (stat(path.c_str(), &buffer) == 0 && S_ISREG(buffer.st_mode));
}

string tips(int i){
    switch(i){
        case 0:
            return "Hello Cudone !!!";
        case 1:
            return "Error : code(1) : No input file after argument \"-i\" !!!";
        case 2:
            return "Error : code(2) : Command not found : ";
        case 3:
            return "Error : code(3) : No output file name after argument \"-o\" !!!";
        case 4:
            return "Error : code(4) : 404 not found File : ";
        default:
            return "\n";
    }
}

void hello(){
    printf("Cudone - Programing Language Compiler\n");
    printf("Copyright © Catrol, 2021\n");
    printf("\n");
    printf("View more info from the author with the address:\n");
    printf("https://blog.catrol.cn\n");
}

struct com_task{
    string inputFileName, outputFileName = "ouput.exe";
    bool binded = false;
};

const string cmds[cmdNUM] = {"-h", "-hello", "-i", "-o"};
queue<string> err;
queue<com_task> tasks;

void input(char* fileName){
    string fn = fileName;
    com_task ct;
    ct.inputFileName = fn;
    tasks.push(ct);
}

void output(char* tarName){
    string tn = tarName;
    int size = tasks.size();
    for(int i = 0; i < size; ++ i){
        com_task ct = tasks.front();
        if(!ct.binded){
            ct.outputFileName = tn;
            ct.binded = true;
            tasks.push(ct);
            tasks.pop();
            break;
        }else{
            tasks.push(ct);
            tasks.pop();
        }
    }
}

void processor(char* argv[], int num){
    for(int i = 1; i < num; ++ i){
        string argu = argv[i];
        int index = -1;
        for(int i = 0; i < cmdNUM; ++ i){
            if(argu == cmds[i]){
                index = i;
                break;
            }
        }
        switch(index){
            case 0:
                hello();
                break;
            case 1:
                printf("%s\n", tips(0).c_str());
                break;
            case 2:
                if(i + 1 == num){
                    err.push(tips(1));
                }else{
                    ++ i;
                    input(argv[i]);
                }
                break;
            case 3:
                if(i + 1 == num){
                    err.push(tips(3));
                }else{
                    ++ i;
                    output(argv[i]);
                }
                break;
            default:
                string info = tips(2);
                info += argu;
                err.push(info);
                break;
        }
    }
}

string& replace_all(string& src, const string& old_value, const string& new_value) {
    for (string::size_type pos(0); pos != string::npos; pos += new_value.length()) {
        if ((pos = src.find(old_value, pos)) != string::npos) {
            src.replace(pos, old_value.length(), new_value);
        }
        else break;
    }
    return src;
}

void writeTXT(string name, string content, bool cover){
    ofstream write(name, cover ? ios::trunc : ios::app);
    if (write.is_open()) {//如果成功的话        
        write << content << endl;  
        write.close();
    }
}

inline string read(const char* filename){
    ifstream file(filename);
    string content = "";
    if(file){
        stringstream buffer;
        buffer << file.rdbuf();
        content = buffer.str();
    }
    file.close();
    return content;
}

void compile(){
    int size = tasks.size();
    for(int i = 0; i < size; ++ i){
        com_task ct = tasks.front();
        if(IsFile(ct.inputFileName)){
            // string str = read(ct.inputFileName.c_str());
            // wifstream wifs(ct.inputFileName.c_str());
            // wstring s;
            // while(wifs.get(tmp))
            // {
            //     s.push_back(tmp);
            // }
            // wcout << fileContent << endl;
            string str;
            fstream reader(ct.inputFileName, fstream::in);
            fstream writter(ct.outputFileName, fstream::out);
            while(getline(reader, str)){
                replace_all(str, "#导入 ", "#include ");
                replace_all(str, " 主函数(", " main(");
                replace_all(str, "数", "int");
                replace_all(str, " 输出(\"", " printf(\"");
                replace_all(str, " 返回 ", " return ");
                for(int i = 0; i < str.length(); ++ i){
                    switch(str[i]){
                        case '<':
                            if(str[i + 1] == 'C' && str[i + 2] == 'u' && str[i + 3] == 'd' && str[i + 4] == 'o' && str[i + 5] == 'n' && str[i + 6] == 'e' && str[i + 7] == '>'){
                                str[i + 1] = '\0', str[i + 2] = '\0', str[i + 3] = '\0', str[i + 4] = '\0', str[i + 5] = '\0', str[i + 6] = '\0';
                                str.insert(i + 1, "bits/stdc++.h");
                            }
                            break;
                    }
                }
                cout << str << endl;
                writter << str << endl;
            }
            reader.close();
            writter.close();
            // wstring ss = to_wide_string(str);
            // wofstream fs;
            // fs.open(ct.outputFileName.c_str());
            // // locale utf8_locale(locale(), new utf8cvt<false>);
            // // fs.imbue(utf8_locale);
            // fs << ss.c_str() << endl;
            // fs.close();
            // ofstream out;
            // out.open(ct.outputFileName.c_str(), ios::out);
            // unsigned char smarker[3];
            // smarker[0] = 0xEF;
            // smarker[1] = 0xBB;
            // smarker[2] = 0xBF;
            // out << smarker << str;
            // out.close();
            // freopen(ct.outputFileName.c_str(), "w", stdout);
            // cout << to_byte_string(ss).c_str() << endl;
            // freopen("/dev/tty", "w", stdout);
            // freopen("/dev/tty", "r", stdin);
        }
        tasks.push(ct);
        tasks.pop();
        rnrn
    }
}

int main(int argc, char* argv[]){
    // locale china("chs");
    // wcin.imbue(china);//use locale object
    // wcout.imbue(china);
    if(argc == 1){
        err.push(tips(1));
    }else{
        processor(argv, argc);
    }
    if(!err.empty()){
        int size = err.size();
        for(int i = 0; i < size; ++ i){
            printf("%s", err.front().c_str());
            err.pop();
            printf("\n");
        }
    }
    if(!tasks.empty()){
        printf("Your compile tasks list produced !!!\n");
        rnrn
        int size = tasks.size();
        for(int i = 0; i < size; ++ i){
            com_task ct = tasks.front();
            printf("task(%d) :\n\t-i\t%s\n\t-o\t%s\n", i, ct.inputFileName.c_str(), ct.outputFileName.c_str());
            tasks.push(ct);
            tasks.pop();
        }
        rnrn
        bool loopTime = false;
        while(true){
            if(loopTime){
                printf("\nPlease check in \"Y\" to confirm or \"n\" to cancel !\n");
            }
            printf("Do you want to compile all of them now ? [Y/n] :");
            string in; getline(cin, in);
            if(in[0] == 'n' && in.length() == 1){
                rnrn
                printf("You have cancled all compile tasks !\n");
                printf("Cudone Compiler exited.\n");
                return 0;
            }else if(in[0] == 'Y' && in.length() == 1){
                break;
            }else{
                loopTime = true;
            }
        }
        rnrn
        compile();
    }
    return 0;
}
