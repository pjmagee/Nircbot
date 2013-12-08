class Response
	
	include System::Collections::Generic
	include Nircbot::Core::Irc::Messages	
	include Nircbot::Core::Irc::Messages::IResponse

	attr_accessor :message
	attr_accessor :message_type
	attr_accessor :message_format
	attr_accessor :targets	
	
	def initialize(message, targets, message_format, message_type)
		@targets = targets
		@message = message
		@message_type = message_type
		@message_format = message_format
		@targets = targets
	end	
	
	def initialize
		@message = nil
		@message_type = MessageType.Public
		@message_format = MessageFormat.Message
		@targets = System::Collections::Generic::List.of(String).new
	end
	
	def targets
		@targets
	end

end