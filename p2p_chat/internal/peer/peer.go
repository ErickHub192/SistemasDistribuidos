package peer

import (
	"bufio"
	"fmt"
	"io"
	"net"
	"os"
	"sync"
)

var username string

// Inicia el listener para aceptar conexiones entrantes y enviar mensajes
func StartListening(port string, user string) {
	username = user

	listener, err := net.Listen("tcp", ":"+port)
	if err != nil {
		fmt.Println("Failed to start listener:", err.Error())
		return
	}
	defer listener.Close()

	fmt.Printf("Peer is listening on port %v...\n", port)

	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Failed to accept connection:", err.Error())
			continue
		}

		fmt.Println("New peer connected.")

		// Permitir enviar y recibir mensajes
		var wg sync.WaitGroup
		wg.Add(2)

		go func() {
			defer wg.Done()
			handleConnection(conn)
		}()

		go func() {
			defer wg.Done()
			sendMessage(conn)
		}()

		wg.Wait()
	}
}

// Conecta un peer a otro ya existente
func ConnectToPeer(address string, user string) {
	username = user

	conn, err := net.Dial("tcp", address)
	if err != nil {
		fmt.Println("Failed to connect to peer:", err.Error())
		return
	}
	fmt.Println("Connected to peer at", address)

	var wg sync.WaitGroup
	wg.Add(2)

	// Mantiene activa la recepción de mensajes
	go func() {
		defer wg.Done()
		receiveMessage(conn)
	}()

	// Mantiene activa la escritura de mensajes
	go func() {
		defer wg.Done()
		sendMessage(conn)
	}()

	wg.Wait()
	conn.Close()
	fmt.Println("Connection closed.")
}

// Maneja una conexión entrante desde un peer
func handleConnection(conn net.Conn) {
	defer conn.Close()
	reader := bufio.NewReader(conn)

	fmt.Println("Connection established with peer")

	for {
		message, err := reader.ReadString('\n')
		if err == io.EOF {
			fmt.Println("Peer disconnected.")
			break
		} else if err != nil {
			fmt.Println("Error reading from peer:", err.Error())
			break
		}
		fmt.Print("[MESSAGE] " + message)
	}
}

// Recibe mensajes de un peer conectado
func receiveMessage(conn net.Conn) {
	reader := bufio.NewReader(conn)

	for {
		message, err := reader.ReadString('\n')
		if err == io.EOF {
			fmt.Println("Peer disconnected.")
			break
		} else if err != nil {
			fmt.Println("Error receiving message:", err.Error())
			break
		}
		fmt.Print("[MESSAGE] " + message)
	}
}

// Envía mensajes a un peer conectado
func sendMessage(conn net.Conn) {
	writer := bufio.NewWriter(conn)
	reader := bufio.NewReader(os.Stdin)

	fmt.Println("Connected to peer. Type your message:")

	for {
		fmt.Print(username + ": ")
		message, err := reader.ReadString('\n')
		if err != nil {
			fmt.Println("Failed to read input:", err.Error())
			continue
		}

		_, err = writer.WriteString(username + ": " + message)
		if err != nil {
			fmt.Println("Failed to send message:", err.Error())
			break
		}
		writer.Flush()
	}
}
