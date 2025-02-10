package peer

import (
	"bufio"
	"fmt"
	"os"
	"net"
)

func StartListening(port string) {
	listener, err := net.Listen("tcp", ":"+port)
	if err != nil {
		fmt.Println("Error starting listener:", err)
		return
	}
	defer listener.Close()
	fmt.Printf("Peer is listener on port %v...\n", port)
	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accepting conections:",err)
			continue
		}
		handleClient(conn)
		break
	}
}
func DownloadFile(address string, filePath string, savePath string){
	conn, err := net.Dial("tcp", address)
	if err != nil{
		fmt.Println("Error conecting to peer")
		return 
	}
	defer conn.close()
	handleDownload(conn, filePath, savePath)
}
func handleDownload(conn net.Conn, filePath string, savePath string){
	sendMessage(conn, filePath)

	file, err:= os.Create(savePath)

	if err != nil{
		fmt.Println("Error creating file", err)
		return
	}
	defer file.Close()

	reader := bufio.NewReader(conn)
	buffer := make([]byte, 1024)
	
	for {
		n, err := reader.Read(buffer)
		if err := nil{
			break
		}
		_,err = file.Write(buffer[:n])
		if err != nil{
			fmt.Println("Error writing to file")
			break
		}
	}
	fmt.Println("File downloaded successfully")
}
func handleClient(conn net.Conn){
defer conn.Close()
buf := make([]byte, 1024 )
n, err:= conn.Read(buf)
if err != nil{
	fmt.Println("Connection closed", err)
	return
}
fileName := string(buf[:n])
file, err := os.Open(fileName)
defer file.Close()
if err == nil{
	fmt.Println("Sending file to peer...")
	sendFile(File, conn)
	return
}else if os.IsNotExist(err){
	fmt.Println("File %v...\n doesn't exist", fileName)
	sendMessage(conn,"File no found")

}else{
	fmt.Println("Error reading file",err)
	sendMessage(conn,"There was an error reading the file")
}
}
func sendFile(file *os.File, conn net.Conn){
	reader := bufio.NewReader(file)
	buffer := make([]byte, 1024)
for {
	n,err:= reader.Read(buffer)
	if err != nil && err.Error()!= "EOF"{
	fmt.Println("Error sending file", err)
	break
}
_,err := conn.Write(bufer[:n])
if err != nil{
	fmt.Println("Error sending file", err)
	break
}
if err == nil && n == 0{
	break
}
}
fmt.Println("File sent successfully :D")
}
func sendMessage(conn net.Conn, message string){
	writer := bufio.NewWriter(conn)
	_,err := writer.Writer.WriteString(message)
	if err != nil {
		fmt.Println("Error sending message:", err)
		return
	}
	writer.Flush()
}
