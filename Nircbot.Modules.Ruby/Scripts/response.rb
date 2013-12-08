class Response
	
	include Nircbot::Core::Module
	include Nircbot::Core::Irc::Messages
	include Nircbot::Core::Irc::Messages::IResponse

	attr_accessor :message
	attr_accessor :message_type
	attr_accessor :message_format
	attr_accessor :targets
	
	def initialize
		@targets = System::Collections::Generic::List.of(String).new
		@message = ""
		@message_type = MessageType.Public
		@message_format = MessageFormat.Message
		
		print
		
	end
	
	def print
		puts @targets
		puts @message
		puts @message_type
		puts @message_format
	end
	
	def add_target(target)
		@targets.add target
		puts "Added #{target} to targets"
	end
	
	def remove_target(target)		
		@targets.remove target
		puts "Removed #{target} from targets"
	end
	
	def print_targets
		puts "Targets for response message: "	
		@targets.each do |target|
			puts target
		end			
	end

end