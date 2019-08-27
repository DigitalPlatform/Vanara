﻿using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Adds a dynamic function table to the dynamic function table list.</summary>
		/// <param name="FunctionTable">
		/// A pointer to an array of function entries. For a definition of the <c>PRUNTIME_FUNCTION</c> type, see rtlsupportapi.h. For more
		/// information on runtime function entries, see the calling convention documentation for the processor.
		/// </param>
		/// <param name="EntryCount">The number of entries in the FunctionTable array.</param>
		/// <param name="BaseAddress">
		/// The base address to use when computing full virtual addresses from relative virtual addresses of function table entries.
		/// </param>
		/// <returns>If the function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>
		/// Function tables are used on 64-bit Windows to determine how to unwind or walk the stack. These tables are usually generated by
		/// the compiler and stored as part of the image. However, applications must provide the function table for dynamically generated
		/// code. For more information about function tables, see the architecture guide for your system.
		/// </para>
		/// <para>
		/// This function is useful for code that is generated from a template or generated only once during the life of the process. For
		/// more dynamically generated code, use the RtlInstallFunctionTableCallback function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtladdfunctiontable NTSYSAPI BOOLEAN RtlAddFunctionTable(
		// PRUNTIME_FUNCTION FunctionTable, DWORD EntryCount, DWORD64 BaseAddress );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "4717f29e-c5f8-4b02-a7c8-edd065f1c793")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlAddFunctionTable([In] IMAGE_RUNTIME_FUNCTION_ENTRY[] FunctionTable, uint EntryCount, ulong BaseAddress);

		/// <summary>Retrieves a context record in the context of the caller.</summary>
		/// <param name="ContextRecord">A pointer to a CONTEXT structure.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlcapturecontext NTSYSAPI VOID RtlCaptureContext( PCONTEXT
		// ContextRecord );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "e2ce0cde-43ab-4681-be66-bd7509fd6ca2")]
		public static extern void RtlCaptureContext(ref CONTEXT ContextRecord);

		/// <summary>Retrieves a context record in the context of the caller.</summary>
		/// <param name="contextFlags">
		/// The context flags to specify what aspects of the context to capture. See <see cref="CONTEXT_FLAG"/> for pre-configured values.
		/// </param>
		/// <returns>The captured <c>CONTEXT</c> structure.</returns>
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "e2ce0cde-43ab-4681-be66-bd7509fd6ca2")]
		public static CONTEXT RtlCaptureContext(uint contextFlags = uint.MaxValue)
		{
			if (contextFlags == uint.MaxValue) contextFlags = CONTEXT_FLAG.CONTEXT_ALL;
			var ctx = new CONTEXT { ContextFlags = contextFlags };
			RtlCaptureContext(ref ctx);
			return ctx;
		}

		/// <summary>Removes a dynamic function table from the dynamic function table list.</summary>
		/// <param name="FunctionTable">
		/// A pointer to an array of function entries that were previously passed to RtlAddFunctionTable or an identifier previously passed
		/// to RtlInstallFunctionTableCallback. For a definition of the <c>PRUNTIME_FUNCTION</c> type, see rtlsupportapi.h.
		/// </param>
		/// <returns>If the function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>.</returns>
		/// <remarks>
		/// Function tables are used on 64-bit Windows to determine how to unwind or walk the stack. These tables are usually generated by
		/// the compiler and stored as part of the image. However, applications must provide the function table for dynamically generated
		/// code. For more information about function tables, see the architecture guide for your system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtldeletefunctiontable NTSYSAPI BOOLEAN RtlDeleteFunctionTable(
		// PRUNTIME_FUNCTION FunctionTable );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "42bc3d83-8053-40e9-b153-f68733d0cb2b")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlDeleteFunctionTable([In] IMAGE_RUNTIME_FUNCTION_ENTRY[] FunctionTable);

		/// <summary>Removes a dynamic function table from the dynamic function table list.</summary>
		/// <param name="FunctionTable">
		/// A pointer to an array of function entries that were previously passed to RtlAddFunctionTable or an identifier previously passed
		/// to RtlInstallFunctionTableCallback. For a definition of the <c>PRUNTIME_FUNCTION</c> type, see rtlsupportapi.h.
		/// </param>
		/// <returns>If the function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>.</returns>
		/// <remarks>
		/// Function tables are used on 64-bit Windows to determine how to unwind or walk the stack. These tables are usually generated by
		/// the compiler and stored as part of the image. However, applications must provide the function table for dynamically generated
		/// code. For more information about function tables, see the architecture guide for your system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtldeletefunctiontable NTSYSAPI BOOLEAN RtlDeleteFunctionTable(
		// PRUNTIME_FUNCTION FunctionTable );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "42bc3d83-8053-40e9-b153-f68733d0cb2b")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlDeleteFunctionTable([In] ulong FunctionTable);

		/// <summary>Adds a dynamic function table to the dynamic function table list.</summary>
		/// <param name="TableIdentifier">
		/// The identifier for the dynamic function table callback. The two low-order bits must be set. For example, BaseAddress|0x3.
		/// </param>
		/// <param name="BaseAddress">The base address of the region of memory managed by the callback function.</param>
		/// <param name="Length">The size of the region of memory managed by the callback function, in bytes.</param>
		/// <param name="Callback">
		/// A pointer to the callback function that is called to retrieve the function table entries for the functions in the specified
		/// region of memory. For a definition of the <c>PGET_RUNTIME_FUNCTION_CALLBACK</c> type, see rtlsupportapi.h.
		/// </param>
		/// <param name="Context">A pointer to the user-defined data to be passed to the callback function.</param>
		/// <param name="OutOfProcessCallbackDll">
		/// <para>
		/// An optional pointer to a string that specifies the path of a DLL that provides function table entries that are outside the process.
		/// </para>
		/// <para>
		/// When a debugger unwinds to a function in the range of addresses managed by the callback function, it loads this DLL and calls the
		/// <c>OUT_OF_PROCESS_FUNCTION_TABLE_CALLBACK_EXPORT_NAME</c> function, whose type is <c>POUT_OF_PROCESS_FUNCTION_TABLE_CALLBACK</c>.
		/// For more information, see the definitions of these items in rtlsupportapi.h.
		/// </para>
		/// </param>
		/// <returns>If the function succeeds, the return value is <c>TRUE</c>. If the function fails, the return value is <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>
		/// Function tables are used on 64-bit Windows to determine how to unwind or walk the stack. These tables are usually generated by
		/// the compiler and stored as part of the image. However, applications must provide the function table for dynamically generated
		/// code. For more information about function tables, see the architecture guide for your system.
		/// </para>
		/// <para>
		/// This function is useful for very dynamic code. The application specifies the memory range for the generated code, but does not
		/// need to generate a table until it is needed by an unwind request. At that time, the system calls the callback function with the
		/// Context and the control address. The callback function must return the runtime function entry for the specified address. Be sure
		/// to avoid creating a deadlock between the callback function and the code generator.
		/// </para>
		/// <para>
		/// For code that is generated from a template or generated only once during the life of the process, use the RtlAddFunctionTable function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlinstallfunctiontablecallback NTSYSAPI BOOLEAN
		// RtlInstallFunctionTableCallback( DWORD64 TableIdentifier, DWORD64 BaseAddress, DWORD Length, PGET_RUNTIME_FUNCTION_CALLBACK
		// Callback, PVOID Context, PCWSTR OutOfProcessCallbackDll );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "63b35b17-0b0e-46ed-9dbf-98290ab08bd1")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlInstallFunctionTableCallback(ulong TableIdentifier, ulong BaseAddress, uint Length, GetRuntimeFunctionCallback Callback, IntPtr Context = default, [MarshalAs(UnmanagedType.LPWStr)] string OutOfProcessCallbackDll = null);

		/// <summary>Searches the active function tables for an entry that corresponds to the specified PC value.</summary>
		/// <param name="ControlPc">The virtual address of an instruction bundle within the function.</param>
		/// <param name="ImageBase">The base address of module to which the function belongs.</param>
		/// <param name="HistoryTable">
		/// <para>The global pointer value of the module.</para>
		/// <para>This parameter has a different declaration on x64 and ARM systems. For more information, see x64 Definition and ARM Definition.</para>
		/// </param>
		/// <returns>
		/// If there is no entry in the function table for the specified PC, the function returns <c>NULL</c>. Otherwise, the function
		/// returns the address of the function table entry that corresponds to the specified PC.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtllookupfunctionentry NTSYSAPI PRUNTIME_FUNCTION
		// RtlLookupFunctionEntry( DWORD64 ControlPc, PDWORD64 ImageBase, PUNWIND_HISTORY_TABLE HistoryTable );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "624b97fb-0453-4f47-b6bd-92aa14705e78")]
		public static extern IntPtr RtlLookupFunctionEntry(ulong ControlPc, out ulong ImageBase, out UNWIND_HISTORY_TABLE HistoryTable);

		/// <summary>Retrieves the base address of the image that contains the specified PC value.</summary>
		/// <param name="PcValue">
		/// The PC value. The function searches all modules mapped into the address space of the calling process for a module that contains
		/// this value.
		/// </param>
		/// <param name="BaseOfImage">
		/// The base address of the image containing the PC value. This value must be added to any relative addresses in the headers to
		/// locate the image.
		/// </param>
		/// <returns>
		/// <para>If the PC value is found, the function returns the base address of the image that contains the PC value.</para>
		/// <para>If no image contains the PC value, the function returns <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlpctofileheader NTSYSAPI PVOID RtlPcToFileHeader( PVOID
		// PcValue, PVOID *BaseOfImage );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "690c9f20-d471-49c9-a40c-28926f03acac")]
		public static extern IntPtr RtlPcToFileHeader(IntPtr PcValue, out IntPtr BaseOfImage);

		/// <summary>Restores the context of the caller to the specified context record.</summary>
		/// <param name="ContextRecord">A pointer to a CONTEXT structure.</param>
		/// <param name="ExceptionRecord">
		/// <para>A pointer to an EXCEPTION_RECORD structure. This parameter is optional and should typically be <c>NULL</c>.</para>
		/// <para>
		/// An exception record is used primarily with long jump and C++ catch-throw support. If the <c>ExceptionCode</c> member is
		/// STATUS_LONGJUMP, the <c>ExceptionInformation</c> member contains a pointer to a jump buffer. <c>RtlRestoreContext</c> will copy
		/// the non-volatile state from the jump buffer in to the context record before the context record is restored.
		/// </para>
		/// <para>
		/// If the <c>ExceptionCode</c> member is STATUS_UNWIND_CONSOLIDATE, the <c>ExceptionInformation</c> member contains a pointer to a
		/// callback function, such as a catch handler. <c>RtlRestoreContext</c> consolidates the call frames between its frame and the frame
		/// specified in the context record before calling the callback function. This hides frames from any exception handling that might
		/// occur in the callback function. The difference between this and a typical unwind is that the data on the stack is still present,
		/// so frame data such as a throw object is still available. The callback function returns a new program counter to update in the
		/// context record, which is then used in a normal restore context.
		/// </para>
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlrestorecontext NTSYSAPI VOID RtlRestoreContext( PCONTEXT
		// ContextRecord, _EXCEPTION_RECORD *ExceptionRecord );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "f5304d17-bc67-4e0f-a535-efca4e65c74c")]
		public static extern void RtlRestoreContext(ref CONTEXT ContextRecord, ref EXCEPTION_RECORD ExceptionRecord);

		/// <summary>Initiates an unwind of procedure call frames.</summary>
		/// <param name="TargetFrame">
		/// A pointer to the call frame that is the target of the unwind. If this parameter is <c>NULL</c>, the function performs an exit unwind.
		/// </param>
		/// <param name="TargetIp">The continuation address of the unwind. This parameter is ignored if TargetFrame is <c>NULL</c>.</param>
		/// <param name="ExceptionRecord">A pointer to an EXCEPTION_RECORD structure.</param>
		/// <param name="ReturnValue">A value to be placed in the integer function return register before continuing execution.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlunwind NTSYSAPI VOID RtlUnwind( PVOID TargetFrame, PVOID
		// TargetIp, PEXCEPTION_RECORD ExceptionRecord, PVOID ReturnValue );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "254b2547-9d3d-468f-a360-20a12e9dd82e")]
		public static extern void RtlUnwind([In, Optional] IntPtr TargetFrame, [In, Optional] IntPtr TargetIp, in EXCEPTION_RECORD ExceptionRecord, IntPtr ReturnValue);

		/// <summary>Initiates an unwind of procedure call frames.</summary>
		/// <param name="TargetFrame">
		/// A pointer to the call frame that is the target of the unwind. If this parameter is <c>NULL</c>, the function performs an exit unwind.
		/// </param>
		/// <param name="TargetIp">The continuation address of the unwind. This parameter is ignored if TargetFrame is <c>NULL</c>.</param>
		/// <param name="ExceptionRecord">A pointer to an EXCEPTION_RECORD structure.</param>
		/// <param name="ReturnValue">A value to be placed in the integer function return register before continuing execution.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlunwind NTSYSAPI VOID RtlUnwind( PVOID TargetFrame, PVOID
		// TargetIp, PEXCEPTION_RECORD ExceptionRecord, PVOID ReturnValue );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "254b2547-9d3d-468f-a360-20a12e9dd82e")]
		public static extern void RtlUnwind([In, Optional] IntPtr TargetFrame, [In, Optional] IntPtr TargetIp, [In, Optional] IntPtr ExceptionRecord, IntPtr ReturnValue);

		/// <summary>Initiates an unwind of procedure call frames.</summary>
		/// <param name="TargetFrame">
		/// A pointer to the call frame that is the target of the unwind. If this parameter is <c>NULL</c>, the function performs an exit unwind.
		/// </param>
		/// <param name="TargetIp">The continuation address of the unwind. This parameter is ignored if TargetFrame is <c>NULL</c>.</param>
		/// <param name="ExceptionRecord">A pointer to an EXCEPTION_RECORD structure.</param>
		/// <param name="ReturnValue">A value to be placed in the integer function return register before continuing execution.</param>
		/// <param name="ContextRecord">A pointer to a CONTEXT structure that stores context during the unwind operation.</param>
		/// <param name="HistoryTable">
		/// A pointer to the unwind history table. This structure is processor specific. For definitions of this structure, see Winternl.h.
		/// </param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>The <c>FRAME_POINTERS</c> structure is defined as follows:</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlunwindex NTSYSAPI VOID RtlUnwindEx( PVOID TargetFrame, PVOID
		// TargetIp, PEXCEPTION_RECORD ExceptionRecord, PVOID ReturnValue, PCONTEXT ContextRecord, PUNWIND_HISTORY_TABLE HistoryTable );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "3d2d8778-311e-4cc1-b280-4f83ab457755")]
		public static extern void RtlUnwindEx([In, Optional] IntPtr TargetFrame, [In, Optional] IntPtr TargetIp, in EXCEPTION_RECORD ExceptionRecord, IntPtr ReturnValue, in CONTEXT ContextRecord, in UNWIND_HISTORY_TABLE HistoryTable);

		/// <summary>Initiates an unwind of procedure call frames.</summary>
		/// <param name="TargetFrame">
		/// A pointer to the call frame that is the target of the unwind. If this parameter is <c>NULL</c>, the function performs an exit unwind.
		/// </param>
		/// <param name="TargetIp">The continuation address of the unwind. This parameter is ignored if TargetFrame is <c>NULL</c>.</param>
		/// <param name="ExceptionRecord">A pointer to an EXCEPTION_RECORD structure.</param>
		/// <param name="ReturnValue">A value to be placed in the integer function return register before continuing execution.</param>
		/// <param name="ContextRecord">A pointer to a CONTEXT structure that stores context during the unwind operation.</param>
		/// <param name="HistoryTable">
		/// A pointer to the unwind history table. This structure is processor specific. For definitions of this structure, see Winternl.h.
		/// </param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>The <c>FRAME_POINTERS</c> structure is defined as follows:</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-rtlunwindex NTSYSAPI VOID RtlUnwindEx( PVOID TargetFrame, PVOID
		// TargetIp, PEXCEPTION_RECORD ExceptionRecord, PVOID ReturnValue, PCONTEXT ContextRecord, PUNWIND_HISTORY_TABLE HistoryTable );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "3d2d8778-311e-4cc1-b280-4f83ab457755")]
		public static extern void RtlUnwindEx([In, Optional] IntPtr TargetFrame, [In, Optional] IntPtr TargetIp, [In, Optional] IntPtr ExceptionRecord, IntPtr ReturnValue, in CONTEXT ContextRecord, [In, Optional] IntPtr HistoryTable);

		/*
		public static extern void RtlCaptureStackBackTrace();
		public static extern void RtlCompareMemory();
		public static extern void RtlCopyMemory();
		public static extern void RtlFillMemory();

		/// <summary>Retrieves the invocation context of the function that precedes the specified function context.</summary>
		/// <param name="HandlerType">
		/// <para>The handler type. This parameter can be one of the following values.</para>
		/// <para>This parameter is only present on x64.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>UNW_FLAG_NHANDLER0x0</term>
		/// <term>The function has no handler.</term>
		/// </item>
		/// <item>
		/// <term>UNW_FLAG_EHANDLER0x1</term>
		/// <term>The function has an exception handler that should be called.</term>
		/// </item>
		/// <item>
		/// <term>UNW_FLAG_UHANDLER0x2</term>
		/// <term>The function has a termination handler that should be called when unwinding an exception.</term>
		/// </item>
		/// <item>
		/// <term>UNW_FLAG_CHAININFO0x4</term>
		/// <term>The FunctionEntry member is the contents of a previous function table entry.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="ImageBase">The base address of the module to which the function belongs.</param>
		/// <param name="ControlPC">The virtual address where control left the specified function.</param>
		/// <param name="FunctionEntry">
		/// The address of the function table entry for the specified function. To obtain the function table entry, call the
		/// <c>RtlLookupFunctionEntry</c> function.
		/// </param>
		/// <param name="ContextRecord">A pointer to a <c>CONTEXT</c> structure that represents the context of the previous frame.</param>
		/// <param name="InFunction">
		/// <para>
		/// The location of the PC. If this parameter is 0, the PC is in the prologue, epilogue, or a null frame region of the function. If
		/// this parameter is 1, the PC is in the body of the function.
		/// </para>
		/// <para>This parameter is not present on x64.</para>
		/// </param>
		/// <param name="EstablisherFrame">
		/// <para>
		/// A pointer to a <c>FRAME_POINTERS</c> structure that receives the establisher frame pointer value. The real frame pointer is
		/// defined only if InFunction is 1.
		/// </para>
		/// <para>This parameter is of type <c>PULONG64</c> on x64.</para>
		/// </param>
		/// <param name="ContextPointers">An optional pointer to a context pointers structure.</param>
		/// <returns>This function returns a pointer to an EXCEPTION_ROUTINE callback function.</returns>
		// PEXCEPTION_ROUTINE WINAPI RtlVirtualUnwind( _In_ HandlerType, _In_ ImageBase, _In_ ControlPC, _In_ FunctionEntry, _Inout_
		// ContextRecord, _Out_ InFunction, _Out_ EstablisherFrame, _Inout_opt_ ContextPointers); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680617(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, EntryPoint = "RtlVirtualUnwind")]
		[PInvokeData("rtlsupportapi.h", MSDNShortId = "ms680617")]
		public static extern EXCEPTION_ROUTINE RtlVirtualUnwindX64(UNW_FLAGS HandlerType, UIntPtr ImageBase, UIntPtr ControlPC, IntPtr FunctionEntry, ref CONTEXT ContextRecord, out IntPtr HandlerData, out ulong EstablisherFrame, IntPtr ContextPointers);

		/// <summary>The handler type.</summary>
		[Flags]
		public enum UNW_FLAGS : uint
		{
			/// <summary>The function has no handler.</summary>
			UNW_FLAG_NHANDLER = 0x0,
			/// <summary>The function has an exception handler that should be called.</summary>
			UNW_FLAG_EHANDLER = 0x1,
			/// <summary>The function has a termination handler that should be called when unwinding an exception.</summary>
			UNW_FLAG_UHANDLER = 0x2,
			/// <summary>The FunctionEntry member is the contents of a previous function table entry.</summary>
			UNW_FLAG_CHAININFO = 0x4,
			/// <summary>Undocumented.</summary>
			UNW_FLAG_NO_EPILOGUE = 0x80000000,
		}

		public delegate EXCEPTION_DISPOSITION EXCEPTION_ROUTINE(ref EXCEPTION_RECORD ExceptionRecord, IntPtr EstablisherFrame, ref CONTEXT ContextRecord, IntPtr DispatcherContext);
		*/
	}
}