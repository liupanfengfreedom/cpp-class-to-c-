#define DLLDIR_EX
#ifdef DLLDIR_EX
#define DLLDIR  __declspec(dllexport)     // export DLL information
#else
#define DLLDIR  __declspec(dllimport)     // import DLL information
#endif
// The extern "C" declaration allows mixed languages compactability, it prevents
// the C++ compiler from using decorated (modified) names for the functions 
extern "C" {
	int DLLDIR DLLfunwrit(int);
	int DLLDIR DLLfunread(int);
	int DLLDIR DLLfun2(int);
	int DLLDIR opensharedmemory();
	int DLLDIR closesharedmemory();
	int DLLDIR writesharedmemory(void*);
	int DLLDIR readsharedmemory(void*);

	int DLLDIR writememory(void*);
	int DLLDIR readmemeory(void*);
	bool DLLDIR LogiSteeringInitialize_kat(bool);
	bool DLLDIR LogiIsConnected_kat(const int index);
	bool DLLDIR LogiUpdate_kat();
	int DLLDIR getsteeringdata_copyvalue_kat(const int index, void*p);
	int DLLDIR addlib_add(int a,int b);

	int DLLDIR importdllclass();
	int DLLDIR dllclassadd(void *,int a,int b);
	int DLLDIR releasedllclass(void *);
};

extern int  DLLDIR DLLArg;

//class DLLDIR Dllclass
class Dllclass
{
public:
	Dllclass();          // Class Constructor
	~Dllclass();         // Class destructor
	int Add(int, int);   // Class function Add
	int Sub(int, int);   // Class function Subtract
	int Arg;             // Warning: you should not import class variables
	// since the DLL object can be dynamically unloaded.
};