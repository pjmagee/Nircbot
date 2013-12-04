class Echo < BotModule

	include Nircbot::Core::Irc::Messages

	def on_private_message(user, message)
			
		response = Response.new				
		response.message_type = MessageType.Private
		response.targets.add user.nick
		client.send_response response

		puts "#{user.nick} #{message}"
	end

	def on_public_message(user, channel, message)
		puts "#{user.nick} #{channel} #{message}"
	end

end