package main

import (
	"fmt"
	"os"

	"github.com/ErickHub192/p2p-chat/internal/peer"
)

func main() {
	// Verifica que se pasen los argumentos necesarios
	if len(os.Args) < 4 {
		fmt.Println("Usage: <operation> <connection> <username>")
		os.Exit(1)
	}

	operation := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]

	if operation == "connect" {
		peer.ConnectToPeer(connection, username)
	} else {
		peer.StartListening(connection, username)
	}
}
