class Echo < BotModule
	
	def on_private_message(user, message)
		
		puts "echo called"
		
		response = Response.new
		response.message = message	
		response.add_target user.nick
		response.print_targets		
		
	end

	def on_public_message(user, channel, message)
		puts "echo: #{user.nick} #{channel} #{message}"
	end
	
	def on_private_message(user, message)
		super
	end

	def on_notice(user, notice)
		super
	end

	def on_user_joined(user, channel)
		super
	end

	def on_user_left(user, channel)
		super
	end

end